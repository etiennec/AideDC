using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Aide_Dilicom3.Config;

namespace Aide_Dilicom3.Network.Actions
{
    /// <summary>
    /// Action to log in Dilicom Web Site.
    /// </summary>
    class ConnectAction : BrowserAction
    {
        public ConnectAction(WebBrowser browser, String connectionUrl, String login, String password)
            : base(browser)
        {
            this.connectionUrl = connectionUrl;
            this.login = login;
            this.password = password;
        }

        private String connectionUrl;
        private String login;
        private String password;

        /// <summary>
        /// Log in on Dilicom Web Site.
        /// 
        /// We don't need to return one document, we just need to log in successfully.
        /// </summary>
        public override XmlDocument doAction()
        {
            // Display login page
            navigate(connectionUrl, Aide_Dilicom3.Config.XPath.get("detection_de_chargement_de_la_page_de_connexion"));

            // Input log & pass fields
            // Populating the forum to try the current login/password 
            HtmlDocument document = getBrowserDocument();
            HtmlElementCollection inputs = document.GetElementsByTagName("INPUT");
            HtmlElement submitButton = null;
            foreach (HtmlElement elt in inputs)
            {
                if (elt.Id.Equals(XPath.get("id_champ_code"), StringComparison.InvariantCultureIgnoreCase))
                {
                    elt.SetAttribute("value", login);
                }
                if (elt.Id.Equals(XPath.get("id_champ_mot_de_passe"), StringComparison.InvariantCultureIgnoreCase))
                {
                    elt.SetAttribute("value", password);
                }
                if (elt.Id.Equals(XPath.get("id_bouton_ok"), StringComparison.InvariantCultureIgnoreCase))
                {
                    submitButton = elt;
                }
            }

            if (submitButton == null)
            {
                logger.Error("Can't find OK button to login (id = '" + XPath.get("id_bouton_ok") + "') in the following HTML: " + getBrowserContents().InnerXml);
                throw new ConnectionFailedException("Le Bouton OK du login et mot de passe n'a pas été trouvé.");
            }

            // Press login
            mshtml.IHTMLElement iButton = (mshtml.IHTMLElement)submitButton.DomElement;
            iButton.click();

            // Wait until the "connected" html token appears. If login & password are not correct, it's up to the end user to do something...
            navigate(null, XPath.get("detection_de_connexion"));


            // We don't do anything special.
            return null;
        }

    }
}
