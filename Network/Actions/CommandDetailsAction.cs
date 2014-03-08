using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Network.Actions;
using System.Xml;

namespace Aide_Dilicom3.Network
{
    class CommandDetailsAction : BrowserAction
    {

        private String commandsListUrl = null;

        private String commandDetailsLoadedXPath = null;

        public CommandDetailsAction(System.Windows.Forms.WebBrowser browser, string commandsListUrl)
            : base(browser) 
        {
            this.commandsListUrl = commandsListUrl;
            this.commandDetailsLoadedXPath = "//span[@class='xxsmall']/a[@href='/commande/suivi.html']";
        }

        public override XmlDocument doAction()
        {
            // We only load the page if we're not already on the right page.
            XmlDocument doc = getBrowserContents();


            logger.Debug("Trying to retrieve list of commandes for URL " + commandsListUrl);

            // We always navigate to the commands page, we don't even check if we're already on the right page.
            this.navigate(commandsListUrl, commandDetailsLoadedXPath);

            // Return Document object for further parsing.
            return getBrowserContents();
        }
    }
}
