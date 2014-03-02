using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Principal;
using System.Windows.Forms;
using System.Xml;
using Aide_Dilicom3.Util;
using log4net;
using System.Collections.Generic;
using System.Text;
using Aide_Dilicom3.Config;
using System.Collections.Specialized;
using Aide_Dilicom3.Parsing;
using System.Text.RegularExpressions;
using Aide_Dilicom3.Network.Actions;


namespace Aide_Dilicom3.Network
{
    /// <summary>
    /// The NetworkInterfaceImpl class does all the work of communicating information between the plugin and the PPM server.
    /// To be independent of IE, it's using the HttpWebRequest class instead of the .NET version of WebBrowser control.
    /// </summary>
    static public class NetworkInterface
    {
        private static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Network");
        private static ILog htmlLogger = LogUtils.getLogger("Aide_Dilicom3.Network.Html");

        private static string lastUrl = Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl;
        private static string origin = Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl;

        private static WebBrowser browser;

        public static WebBrowser Browser
        {
            set 
            { 
                browser = value;
                if (browser != null)
                {
                    browser.ScriptErrorsSuppressed = true;
                }
            }
        }

        public enum RequestType
        {
            CONNEXION, // Simply display connection screen, just to be friendly
            EAN_DETAILS,// Gets the details of a single EAN reference
            COMMANDS_LIST, // Retrieves 20 commands from the commands list
            COMMAND_DETAIL // Retrieve the details of a given command
        }

        // This class is used to store both url and POST parameters to be submitted.
        public class RequestDetails
        {
            public string url = null;
            public StringDictionary parameters = null;
        }


        static NetworkInterface()
        {
            logger.Debug("Starting Network Interface");
        }


        /// <summary>
        /// Returns the URL to be loaded in the browser based on the request type and the submitted parameters.
        /// </summary>
        /// <param name="reqType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static String getUrlForRequest(RequestType reqType, StringDictionary parameters)
        {
            String url = null;

            switch (reqType)
            {
                case RequestType.COMMAND_DETAIL:
                    // The full url is in the "url" parameter, and there is potentially a "p" parameter with the page number.
                    url = relativeToAbsoluteUrl(parameters["url"]);
                    if (parameters.ContainsKey("p"))
                    {
                        url += "&p=" + parameters["p"];
                    }
                    break;
                case RequestType.COMMANDS_LIST: // The page number is passed in GET, in the URL
                    url = getFullUrlFor("liste_commandes") + "?" + NetworkConstants.PARAM_LIST_PAGE + "=" + parameters[NetworkConstants.PARAM_LIST_PAGE];
                    break;
                case RequestType.EAN_DETAILS:
                    url = getFullUrlFor("catalogue");
                    break;
                case RequestType.CONNEXION:
                    url = getFullUrlFor("connexion");
                    break;
                default:
                    logger.Error("Type de requête inconnu: " + reqType);
                    throw new Exception("Unknown Request Type");
            }

            return url;
        }

        private static string getFullUrlFor(string urlIdentifier)
        {
            String relativeUrl = Address.get(urlIdentifier);

            if (string.IsNullOrEmpty(relativeUrl))
            {
                logger.Warn("Couldn't retrieve Relative URL for address id " + urlIdentifier);
                return Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl;
            }

            return relativeToAbsoluteUrl(relativeUrl);
        }

        private static string relativeToAbsoluteUrl(String relativeUrl)
        {
            return Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl + (relativeUrl.StartsWith("/") ? "" : "/") + relativeUrl;
        }


        /// <summary>
        ///  Generate the POST data based on the parameters.
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string getPostDataFromParams(StringDictionary parameters)
        {
            StringBuilder sb = new StringBuilder();

            bool first = true;

            foreach (string key in parameters.Keys)
            {
                if (!first)
                {
                    sb.Append(NetworkConstants.POSTPARAM_DELIMITER);
                }
                else
                {
                    first = false;
                }

                sb.Append(key);
                sb.Append("=");
                sb.Append(parameters[key]);
            }

            return sb.ToString();
        }



        static public XmlDocument retrieve(RequestType reqType, StringDictionary parameters)
        {
            logger.Debug("Starting Request for type: " + reqType.ToString());

            BrowserAction action = getBrowserAction(reqType, parameters);

            XmlDocument doc = action.doAction();

            return doc;
        }

        private static bool isDeconnected(string strResponse)
        {
            if (strResponse.Contains(XPath.get("detection_de_deconnection")))
            {
                logger.Warn("Déconnexion détectée");
                return true;
            }
            else
            {
                return false;
            }
        }

        private static XmlDocument getXmlDocFromHtmlCode(string html)
        {
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

        /// <summary>
        /// Disconnects from the PPM Server (by cleaning the cookies information)
        /// </summary>
        public static void resetSession()
        {
            browser.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
        }

        private static BrowserAction getBrowserAction(RequestType reqType, StringDictionary param)
        {
            switch (reqType)
            {
                case RequestType.CONNEXION:
                    return new ConnectAction(browser, getUrlForRequest(reqType, param), Aide_Dilicom3.Properties.Settings.Default.Login, Aide_Dilicom3.Properties.Settings.Default.Password);
                case RequestType.EAN_DETAILS:
                    return new EanDetailsAction(browser, getUrlForRequest(reqType, param), param[NetworkConstants.PARAM_EAN_EAN]);
                case RequestType.COMMANDS_LIST:
                    return new ListCommandsAction(browser, getUrlForRequest(reqType, param), param[NetworkConstants.PARAM_LIST_PAGE]); 
                default:
                    logger.Error("Type de requête inconnu: " + reqType);
                    throw new Exception("Unknown Request Type");
            }
        }

        public class ProgressIndicatorEventArgs : EventArgs
        {
            public ProgressIndicatorEventArgs(int i)
            {
                percentage = i;
            }

            public int getPercentage() { return percentage; }

            // percentage of progression
            private int percentage = 0;
        }

        public class EanInfoThreadParams
        {
            public EanInfoThreadParams(List<String> p_eanCodes, Hashtable p_additions)
            {
                eanCodes = p_eanCodes;
                additions = p_additions;
            }

            public List<String> getEanCodes() { return eanCodes; }
            public Hashtable getAdditions() { return additions; }


            private List<String> eanCodes;
            private Hashtable additions;
        }
    }
}
