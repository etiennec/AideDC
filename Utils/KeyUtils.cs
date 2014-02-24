using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Utils
{
    public static class KeyUtils
    {
        /// <summary>
        ///  Gets a list of article.blis and turn it into a list of blis
        /// </summary>
        /// <param name="FullKeys"></param>
        /// <param name="nameKey"></param>
        /// <returns></returns>
        public static List<string> getKeysWithoutName(List<String> FullKeys, string nameKey)
        {
            List<String> result = new List<string>();

            foreach (string key in FullKeys)
            {
                result.Add(getKeyWithoutName(key, nameKey));
            }

            return result;
        }

        public static string getKeyWithoutName(String FullKey, string nameKey)
        {
            return FullKey.Substring(nameKey.Length + 1);
        }
    }
}
