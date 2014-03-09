using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Network.Actions;
using System.Xml;
using Aide_Dilicom3.Config;

namespace Aide_Dilicom3.Network
{
    class CommandDetailsAction : BrowserAction
    {

        private String commandsListUrl = null;

        private String commandDetailsLoadedXPath = "//span[@class='xxsmall']/a[@href='/commande/suivi.html']";

        public CommandDetailsAction(System.Windows.Forms.WebBrowser browser, string commandsListUrl)
            : base(browser) 
        {
            this.commandsListUrl = commandsListUrl;
        }

        public override XmlDocument doAction()
        {
            logger.Debug("Trying to retrieve list of commandes for URL " + commandsListUrl);

            String commandNumber = RegExp.matchRegexInfo(RegExp.get("numero.commande.url"), commandsListUrl);
            String pageNumber = RegExp.matchRegexInfo(RegExp.get("numero.page.commande.url"), commandsListUrl);

            if (commandNumber == null)
            {
                throw new Exception("Couldn't find command number in URL "+commandsListUrl);
            }

            // We always navigate to the commands page, and check we're looking at the right command.
            this.navigate(commandsListUrl, XPath.get("detection_numero_detail_commande").Replace("$id$", commandNumber));

            // We then wait until we're sure the page has loaded
            throwExceptionIfNull(this.waitOnXPath(commandDetailsLoadedXPath));

            // Finally, we check whether we're looking at the right page.
            // If no page or page 1, we check for no page or page one.
            if (pageNumber == null || "1".Equals(pageNumber))
            {
                List<String> xpaths = new List<String>();
                xpaths.Add(XPath.get("detection_pas_de_page_detail_commande"));
                xpaths.Add(XPath.get("detection_numero_page_detail_commande").Replace("$page$", "1"));
                throwExceptionIfNull(this.waitOnXPath(xpaths));
            }
            else
            {
                // If page > 1, we check that we're on that specific page.
                throwExceptionIfNull(this.waitOnXPath(XPath.get("detection_numero_page_detail_commande").Replace("$page$", pageNumber)));
            }

            // Return Document object for further parsing.
            return getBrowserContents();
        }

        private void throwExceptionIfNull(String value)
        {
            if (value == null)
            {
                throw new Exception("Waited for an XPath that never arrived in CommandDetailsAction");
            }
        }
    }
}
