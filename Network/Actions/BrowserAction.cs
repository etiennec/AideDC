using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using log4net;
using System.IO;
using Aide_Dilicom3.Util;
using System.Text.RegularExpressions;
using System.Threading;

namespace Aide_Dilicom3.Network.Actions
{
    /// <summary>
    /// Base class for all Web Browsing Actions.Contains basic generic basic operations not linked to any Dilicom webflow.
    /// </summary>
    abstract class BrowserAction
    {
        protected static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Network.Actions.BrowserAction");

        private static int sleepTime = Aide_Dilicom3.Properties.Settings.Default.HtmlCheckInterval;

        // number of times this action has failed (because of timeout) and retried.
        private int retried = 0;

        /// <summary>
        /// WebBrowser object, to be set on object instanciation (mandatory).
        /// </summary>
        protected WebBrowser browser = null;

        public BrowserAction(WebBrowser browser)
        {
            this.browser = browser;
        }

        /// <summary>
        /// Does the actual action. All parameters must have been set by then before calling this method.
        /// </summary>
        /// <returns></returns>
        public abstract XmlDocument doAction();

        /// <summary>
        /// Connect user to Dilicom. Display login page, input username & password, and submit. 
        /// Returns correctly if the main page is loaded with the successful connection HTML element. 
        /// Else, throws a ConnectionFailedException.
        /// </summary>
        protected void connect()
        {
            // Load the login page
            // input login & password
            // Submit form
            // Check for either connected or non connected HTML indicators in the resulting HTML.
        }


        /// <summary>
        /// Convenience method for navigate(string url, List<string> XPathListToMatch) when there is only one XPath expression to match.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="XPathToMatch"></param>
        /// <returns></returns>
        protected String navigate(String url, String xPathToMatch)
        {
            List<String> strs = new List<String>();
            if (xPathToMatch != null)
            {
                strs.Add(xPathToMatch);
            }
            return navigate(url, strs);
        }


        private delegate void navigateDelegate(string url);
        /// <summary>
        /// Entry point to navigate to a page. Take care of delegating call if done from non-UI thread (which should be the way it's done).
        /// </summary>
        /// <param name="url"></param>
        /// <param name="XPathListToMatch"></param>
        /// <returns></returns>
        private void threadSafeNavigate(string url)
        {
            if (browser.InvokeRequired)
            {
                browser.Invoke(new navigateDelegate(threadSafeNavigate), new object[] { url });
            }
            else
            {
                browser.Navigate(url);
            }
        }

        /// <summary>
        /// Navigate to a given URL, waiting for one or more XPath expressions to be found in the source code. 
        /// 
        /// If the provided URL is null, don't do any special navigation, and just wait for the XPaths expressions to be found in the code of the browser.
        /// </summary>
        /// <param name="url"></param>
        /// <param name="XPathListToMatch"></param>
        /// <returns></returns>
        protected String navigate(string url, List<string> XPathListToMatch)
        {
            logger.Debug(url != null ? "Navigating to URL " + url : "Waiting for XPaths to appear in browser HTML");

            // go to the target Url (if any)
            if (url != null)
            {
                threadSafeNavigate(url);
            }

            int timeOut = Aide_Dilicom3.Properties.Settings.Default.Timeout * 1000;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // Loop and check browser code regularly to search for XPath expressions to match.
            do
            {
                String xpathFound = browserHtmlContainsXPaths(XPathListToMatch);
                if (xpathFound != null)
                {
                    return xpathFound;
                }

                // Sleeping a bit before next check.
                System.Threading.Thread.Sleep(sleepTime);

            } while (watch.ElapsedMilliseconds < timeOut);

            // If timeout is reached, reload link.
            logger.Warn("Timeout of " + timeOut + " reached when accessing URL " + url);

            // If max retries is reached. Throw ConnectionFailedException.
            if (retried >= Aide_Dilicom3.Properties.Settings.Default.MaxRetries)
            {
                logger.Error("Failed after " + retried + " tries when trying to reach accessing URL " + url);
                throw new ConnectionFailedException("L'opération a échoué après " + retried + " essais infructueux. Vérifiez la connection internet.");
            }
            else
            {
                // Trying one more time.
                retried++;
                return navigate(url, XPathListToMatch);
            }
        }

        private String browserHtmlContainsXPaths(List<String> xpaths)
        {
            foreach (String xpath in xpaths)
            {
                if (browserHtmlContainsXPath(xpath))
                {
                    logger.Debug("Found XPath " + xpath + " in HTML Code");
                    return xpath;
                }
            }

            return null;
        }

        private bool browserHtmlContainsXPath(String xpath)
        {
            XmlDocument doc = getBrowserContents();

            if (doc == null || string.IsNullOrEmpty(xpath)) { return false; }

            return (doc.SelectSingleNode(xpath) != null);
        }

        private delegate HtmlDocument getBrowserDocumentDelegate();
        protected HtmlDocument getBrowserDocument()
        {
            if (browser.InvokeRequired)
            {
                return (HtmlDocument)browser.Invoke(new getBrowserDocumentDelegate(getBrowserDocument), new object[] { });
            }
            else
            {
                return browser.Document;
            }
        }

        public XmlDocument getBrowserContents()
        {
            HtmlDocument browserDoc = getBrowserDocument();

            if (browserDoc == null)
            {
                return null;
            }
            HtmlElementCollection elems = browserDoc.GetElementsByTagName("HTML");
            if (elems.Count == 1)
            {
                HtmlElement elem = elems[0];
                return getXmlDocFromHtmlCode(elem.OuterHtml);
            }
            else
            {
                return null;
            }
        }

        private static XmlDocument getXmlDocFromHtmlCode(string html)
        {
            // Remove every xmlns info as it's a pain for our simple xpath parsing.
            html = Regex.Replace(html, "xmlns=\"[^\"]*\"", "");

            XmlDocument doc = new XmlDocument();
            using (TextReader reader = new StringReader(html))
            {
                Sgml.SgmlReader sgmlReader = new Sgml.SgmlReader();
                sgmlReader.DocType = "HTML";
                sgmlReader.WhitespaceHandling = WhitespaceHandling.Significant;
                sgmlReader.CaseFolding = Sgml.CaseFolding.ToLower;
                sgmlReader.InputStream = reader;
                doc.Load(sgmlReader);
            }

            return doc;
        }
    }
}
