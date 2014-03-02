using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Network.Actions;
using System.Xml;

namespace Aide_Dilicom3.Network
{
    class ListCommandsAction : BrowserAction
    {

        private String commandsListUrl = null;

        private String commandsPageLoadedXPath = null;

        public ListCommandsAction(System.Windows.Forms.WebBrowser browser, string commandsListUrl, String pageIndex)
            : base(browser) 
        {
            this.commandsListUrl = commandsListUrl;
            this.commandsPageLoadedXPath = "//a[@class='lien_noir_10'][text()='" + pageIndex + "']";
        }

        public override XmlDocument doAction()
        {
            // We only load the page if we're not already on the right page.
            XmlDocument doc = getBrowserContents();

            // If not present (we are not on catalog page), load the catalog page until EAN search field appears.
            if (doc != null && doc.SelectSingleNode(commandsPageLoadedXPath) != null)
            {
                logger.Debug("Already on the right list command page, not loading anything new");
                return doc;
            }


            logger.Debug("Trying to retrieve list of commandes for URL " + commandsListUrl);

            // We always navigate to the commands page, we don't even check if we're already on the right page.
            this.navigate(commandsListUrl, commandsPageLoadedXPath);

            // Return Document object for further parsing.
            return getBrowserContents();
        }
    }
}
