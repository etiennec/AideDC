using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Util;
using System.Text.RegularExpressions;

namespace Aide_Dilicom3.Config
{
    public static class RegExp
    {
        private static PropertiesResourceManager XpathManager = null;

        private static Dictionary<string, Regex> repo = new Dictionary<string, Regex>();

        static RegExp()
        {
            XpathManager = new PropertiesResourceManager("RegExp");
        }

        public static Regex get(string key)
        {
            if (repo.ContainsKey(key))
            {
                return repo[key];
            }
            else
            {
                string RegExpStr = XpathManager.getString(key);

                if (String.IsNullOrEmpty(RegExpStr))
                {
                    repo.Add(key, null);
                    return null;
                }
                else
                {
                    Regex regExp = new Regex("(?imns)" + RegExpStr, RegexOptions.Compiled);
                    repo.Add(key, regExp);
                    return regExp;
                }
            }
        }
    }
}
