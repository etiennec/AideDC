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
    public static class ResumeCommandeParser
    {
        private static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Parsing");

        /// <summary>
        /// Parse a number CommandsCount of commands from the response. CommandsCount should never be higher than 20 in theory.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="CommandsCount"></param>
        /// <returns></returns>
        public static List<ResumeCommande> parseCommandsListResponse(XmlDocument doc, int CommandsCount) {

            List<ResumeCommande> results = new List<ResumeCommande>();

            for (int i = 1; i <= CommandsCount; i++)
            {
                ResumeCommande commande = new ResumeCommande();

                commande.data = ParsingUtils.getData(commande.getKey(), doc, i);

                results.Add(commande);

                if (logger.IsDebugEnabled)
                {
                    logger.Debug("Parsed ResumeCommande data: ");

                    StringBuilder sb = new StringBuilder("\n");

                    foreach (string key in commande.data.Keys)
                    {
                        sb.Append(key);
                        sb.Append(":");
                        sb.AppendLine(commande.data[key]);
                    }
                    logger.Debug(sb.ToString());
                }
            }

            return results;
        }
    }
}

