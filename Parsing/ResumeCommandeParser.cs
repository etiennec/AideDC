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
        /// Parse a number CommandsCount of commands from the response. 
        /// Never returns more than CommandsCount ResumeCommande, but returns less 
        /// if there's less than that in the document to parse.
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="CommandsCount"></param>
        /// <returns></returns>
        public static List<ResumeCommande> parseCommandsListResponse(XmlDocument doc, int CommandsCount) {

            List<ResumeCommande> results = new List<ResumeCommande>();

            for (int i = 1; i <= CommandsCount; i++)
            {
                ResumeCommande commande = new ResumeCommande();

                // We need to increment i because the first tr row is for table headers.
                commande.data = ParsingUtils.getData(commande.getKey(), doc, i+1);

                if (!commande.hasData())
                {
                    logger.Debug("No more results found to parse in Resume Commande after " + results.Count + " commandes");
                    return results;
                }

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

