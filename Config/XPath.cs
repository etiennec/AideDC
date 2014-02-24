using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Util;

namespace Aide_Dilicom3.Config
{
    public static class XPath
    {
        private static PropertiesResourceManager XpathManager = null;

        static XPath()
        {
            XpathManager = new PropertiesResourceManager("Chemins");
        }

        public static string get(string key)
        {
            return XpathManager.getString(key);
        }

        /// <summary>
        ///  Returns all keys starting by "key."
        /// </summary>
        /// <param name="key"></param>
        public static List<string> getKeys(string key)
        {
            return XpathManager.getKeys(key + ".");
        }
    }
}
