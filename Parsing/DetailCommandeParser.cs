using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Data;
using System.Xml;
using log4net;
using Aide_Dilicom3.Util;

namespace Aide_Dilicom3.Parsing
{
    public static class DetailCommandeParser
    {
        private static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Parsing");

        /// <summary>
        /// Parse all the lignes from the doc and return them.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="CommandsCount"></param>
        /// <returns></returns>
        public static List<Ligne> parseCommandDetails(XmlDocument doc)
        {

            List<Ligne> results = new List<Ligne>();

            int i = 1;

            while (ParsingUtils.exist("detection_existence_ligne", doc, i))
            {
                Ligne ligne = new Ligne();

                ligne.data = ParsingUtils.getData(ligne.getKey(), doc, i);

                results.Add(ligne);

                ++i;

                if (logger.IsDebugEnabled)
                {
                    logger.Debug("Parsed ligne data: ");

                    StringBuilder sb = new StringBuilder("\n");

                    foreach (string key in ligne.data.Keys)
                    {
                        sb.Append(key);
                        sb.Append(":");
                        sb.AppendLine(ligne.data[key]);
                    }
                    logger.Debug(sb.ToString());
                }
            }


            return results;
        }
    }
}

