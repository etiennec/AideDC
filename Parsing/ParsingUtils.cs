using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Aide_Dilicom3.Config;
using Aide_Dilicom3.Util;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using Aide_Dilicom3.Utils;
using log4net;

namespace Aide_Dilicom3.Parsing
{
    /// <summary>
    ///  Utility Class for generic parsing operations
    /// </summary>
    public class ParsingUtils
    {
        private static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Parsing");

        /// <summary>
        ///  Returns false if some information is found in the document that let us know that user is not currently connected.
        ///  If nothing like that is found, return true (we suppose user is connected).
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static bool isConnected(XmlDocument doc)
        {
            int matches = doc.SelectNodes(XPath.get("detection_de_non_connexion")).Count;

            if (matches > 0)
            {
                logger.Debug("Found non connection string in document: User is NOT connected");
                return false;
            }
            else
            {
                logger.Debug("Couldn't find non connection string in document: User is ALREADY connected");
                return true;
            }
        }

        public static string getValueFromXPath(XmlDocument doc, string XPathKey)
        {
            string xpath = XPath.get(XPathKey);

            if (string.IsNullOrEmpty(xpath))
            {
                LogUtils.error("Error when retrieving XPathKey " + XPathKey);
                return "";
            }

            return getValueFromXPathString(doc, xpath);
        }

        /// <summary>
        /// Method used for XPath with $i$ or $j$ parameters that must be replaced according to the provided index.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="XPathKey"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string getValueFromXPath(XmlDocument doc, string XPathKey, int index)
        {
            string xpath = getReplacedXPath(XPathKey, index);

            if (string.IsNullOrEmpty(xpath))
            {
                LogUtils.error("Error when retrieving XPathKey " + XPathKey);
                return "";
            }

            return getValueFromXPathString(doc, xpath);
        }

        private static string getReplacedXPath(string XPathKey, int index)
        {
            return XPath.get(XPathKey).Replace("$i$", index.ToString()).Replace("$j$", (index + 1).ToString());
        }

        private static string getValueFromXPathString(XmlDocument doc, string xpath) 
        {
            XmlNodeList results = doc.SelectNodes(xpath);

            if (results.Count == 0)
            {
                LogUtils.debug("Couldn't retrieve xpath element of XPath" + xpath);
                return "";
            }
            else if (results.Count > 1)
            {
                LogUtils.debug("We retrieved more than one element for XPath" + xpath);
            }

            return results[0].InnerText.Trim();
        }

        /// <summary>
        /// Retrieve all the XPaths for the given key, and then extract them from the XmlDocument, using regexp whenever existing
        /// </summary>
        /// <param name="key"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static StringDictionary getData(string stuffName, XmlDocument doc)
        {
            return getData(stuffName, doc, -1);
        }

        /// <summary>
        /// Retrieve all the XPaths for the given key and the given index, and then extract them from the XmlDocument, using regexp whenever existing.
        /// 
        /// The index is ignored if < 0.
        /// </summary>
        /// <param name="stuffName"></param>
        /// <param name="doc"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static StringDictionary getData(string stuffName, XmlDocument doc, int index)
        {
            StringDictionary data = new StringDictionary();

            List<string> Keys = XPath.getKeys(stuffName);

            foreach (string Key in Keys)
            {
                String value = (index >= 0 ? getValueFromXPath(doc, Key, index) : getValueFromXPath(doc, Key));

                Regex regExp = RegExp.get(Key);
                if (!(regExp == null))
                {
                    String valueMatch = RegExp.matchRegexInfo(regExp, value);

                    if (valueMatch == null)
                    {
                        LogUtils.warn("RegEx match failed for regexp " + regExp.ToString() + " on value " + value);
                        value = "";
                    }
                    else
                    {
                        value = valueMatch;
                    }
                }

                value = formatValue(value, Key);

                data.Add(KeyUtils.getKeyWithoutName(Key, stuffName), value); // We remove the key name from the data
            }

            return data;
        }

        /// <summary>
        /// returns true if the xpath of key exists in doc, false else.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static bool exist(string key, XmlDocument doc)
        {
            return exist(key, doc, -1);
        }

        /// <summary>
        /// returns true if the xpath of key with index i exists in doc, false else.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="doc"></param>
        /// <param name="i"></param>
        public static bool exist(string key, XmlDocument doc, int i)
        {
            string xpath = getReplacedXPath(key, i);

            if (string.IsNullOrEmpty(xpath))
            {
                LogUtils.error("Error when retrieving XPathKey " + key);
                return false;
            }

            XmlNodeList results = doc.SelectNodes(xpath);

            if (results.Count == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Format the value according to the special type (date)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="Key"></param>
        /// <returns></returns>
        private static string formatValue(string value, string Key)
        {
            string formattedValue = value;

            if (Key.ToLower().EndsWith(".date"))
            {
                // changing date dd-mm-yyyy to dd/mm/yyyy
                formattedValue = formattedValue.Replace("-", "/");
            }
            else if (Key.ToLower().EndsWith(".prix"))
            {
                formattedValue = formattedValue.Replace("€", "");
                formattedValue = formattedValue.Replace(".", ","); // French use , as decimal separator, and no thousand separator.
                formattedValue = formattedValue.Trim();
            }

            return formattedValue;
        }
    }
}
