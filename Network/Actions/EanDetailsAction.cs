using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Aide_Dilicom3.Config;
using Aide_Dilicom3.Utils;

namespace Aide_Dilicom3.Network.Actions
{
    class EanDetailsAction : BrowserAction
    {

        public EanDetailsAction(WebBrowser browser, String catalogueUrl, String eanCode)
            : base(browser)
        {
            this.catalogueUrl = catalogueUrl;
            this.eanCode = eanCode;
        }

        private String eanFieldXPath = "//input[@id='" + XPath.get("id_champ_ean") + "']";
        private String catalogueUrl = null;
        private String eanCode = null;

        public override System.Xml.XmlDocument doAction()
        {
            logger.Debug("Trying to retrieve Details for EAN code " + eanCode);
            
            // Search for EAN search field in the currently loaded page
            XmlDocument doc = getBrowserContents();

            // If not present (we are not on catalog page), load the catalog page until EAN search field appears.
            if (doc == null || doc.SelectSingleNode(eanFieldXPath) == null)
            {
                navigate(catalogueUrl, eanFieldXPath);
            }

            // Input EAN code & Press Search
            HtmlDocument document = getBrowserDocument();
            HtmlElementCollection inputs = document.GetElementsByTagName("INPUT");
            HtmlElement submitButton = null;
            foreach (HtmlElement elt in inputs)
            {
                if (XPath.get("id_champ_ean").Equals(elt.Id, StringComparison.InvariantCultureIgnoreCase))
                {
                    elt.SetAttribute("value", eanCode);
                }
                if ("submit".Equals(elt.GetAttribute("type"), StringComparison.InvariantCultureIgnoreCase))
                {
                    submitButton = elt;
                }
            }

            if (submitButton == null)
            {
                logger.Error("Can't find Search EAN button in the following catalog page HTML: " + getBrowserContents().InnerXml);
                throw new ConnectionFailedException("Le Bouton de recherche de la page du catalogue n'a pas été trouvé.");
            }

            // Press Search button
            mshtml.IHTMLElement iButton = (mshtml.IHTMLElement)submitButton.DomElement;
            iButton.click();

            // Wait for search result to be loaded.
            navigate(null, XPath.get("code_ean_html").Replace(Aide_Dilicom3.Properties.Settings.Default.EanToken, eanCode));

            // Return Document object for further parsing.
            return getBrowserContents();
        }
    }
}

