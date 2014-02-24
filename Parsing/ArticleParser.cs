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
    public static class ArticleParser
    {
        private static ILog logger = LogUtils.getLogger("Aide_Dilicom3.Parsing");

        public static Article parseEanDetailsResponse(XmlDocument doc) {
            Article article = new Article();

            article.data = ParsingUtils.getData(article.getKey(), doc);

            if (logger.IsDebugEnabled)
            {
                logger.Debug("Parsed Article data: ");

                StringBuilder sb = new StringBuilder("\n");

                foreach (string key in article.data.Keys)
                {
                    sb.Append(key);
                    sb.Append(":");
                    sb.AppendLine(article.data[key]);
                }
                logger.Debug(sb.ToString());
            }

            return article;
        }
    }
}

