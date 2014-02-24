using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using Aide_Dilicom3.Util;

namespace Aide_Dilicom3.Utils
{
    class DilicomUtils
    {
        static private Regex eanCodeNotFoundReg = new Regex(@"(?imns)Code \d+ non trouv", RegexOptions.Compiled);

        static private Regex eanCodeNotValidReg = new Regex(@"(?imns)<p align=""center""><font color=""#000080""><b>Code invalide</b></font></p>", RegexOptions.Compiled);

        static private Regex eanCodeReg = new Regex(@"(?imns)(\D|^)(?<eanCode>(\d){13})(\D|$)", RegexOptions.Compiled);
        
        static private Regex formatDateReg = new Regex(@"(?imns).*(?<day>\d\d)-(?<month>\d\d)-(?<year>\d\d\d\d).*", RegexOptions.Compiled);

        static private Regex orderInfoReg = new Regex(@"(?imns)^\s*<td align=""left""><font size=""2"">(?<destinataire>.+)</font></td>\s+" +
            @"<td><font size=""2"">(?<date_envoi>.+)</font></td>\s+" +
            @"<td><font size=""2"">(?<date_remise>.+)</font></td>\s+" +
            @"<td><font size=""2"">(?<reference>\w+)\s*</font></td>\s+" +
            @"<td align=""right""><font size=""2"">(?<lignes>\d*)</font></td>\s+" +
            @"<td><font size=""2"">(?<exemplaires>\d*)</font></td>\s+" +
            @"<td class=""supprimer""><font size=""2""><a href=""Detailc.cgi\?_gwid=\w*&form_id=Detailc&(?<url_ref>MsgNumb=\d+&Pos=\d*)""><IMG",
            RegexOptions.Compiled);

        // static private Regex orderListItemReg = new Regex(@"(?imns)<!-- suivi_list.tpl -->\s+<tr align=center>.*?</a>\s+</td>\s+</tr>", RegexOptions.Compiled);
        static private Regex orderListItemReg = new Regex(@"(?imns)<!-- suivi_list.tpl -->\s+<tr align=center>.*?</tr>", RegexOptions.Compiled);

        /* static private Regex orderDetailHeaderReg = new Regex(@"(?imns)<td><font face=""Times New Roman"" size=2>\s*" +
                @"<b>:</b>(?<destinataire>.*?)</font>.*" +
                @"<b>:</b>(?<date_envoi>.*?)</font>.*" +
                @"<b>:</b>(?<date_remise>.*?)</font>.*" +
                @"<b>:</b> <font color=""#......"">(?<reference>.*?)</font></font>.*" +
                @"<b>:</b>(?<exp_mode>.*?)</font>.s*" +
                @"<b>:</b>(?<ref_operation>.*?)</font>\s*</td>\s*</tr>\s*</table>",
            RegexOptions.Compiled); */


        static private Regex orderDetailSummaryReg = new Regex(@"(?imns)<td colspan=5><font face=""Times New Roman"">Total pour ce destinataire</font></td>\s*" +
            @"<td align=""right""><font color=""#F70000"" face=""Times New Roman""><b>(?<item_quantity>.*?)<b></font></td>\s*" +
            @"<td align=""right""><font color=""#F70000"" face=""Times New Roman""><b>(?<sum>.*?)<b></font></td>",
            RegexOptions.Compiled);


        static private Regex orderDetailListItemReg = new Regex(@"(?imns)<!-- detailc_list.tpl -->\s*" +
            @"<tr>\s*" +
            @"<td><font size=""2"" face=""Times New Roman""><center>(?<ean_code>.*?)</center></font></td>\s*" +
            @"<td><font size=""2"" face=""Times New Roman"">(?<title>.*?)</font></td>\s*" +
            @"<td><font size=""2"" face=""Times New Roman"">(?<publisher>.*?)</font></td>\s*" +
            @"<td align=""right""><font size=""2"" face=""Times New Roman"">(?<price>.*?)</font></td>\s*" +
            @"<td>(?<ref_line>.*?)</td>\s*" +
            @"<td align=""right""><font size=""2"" face=""Times New Roman"">(?<quantity>.*?)</font></td>\s*" +
            @"<td align=""right""><font size=""2"" face=""Times New Roman"">(?<line_price>.*?)</font></td>\s*",
            RegexOptions.Compiled);

        static private Regex eanDetailsUpdateDateReg = new Regex(@"(?imns)Mise .+? jour : </font>\s*?(?<update_date>.*?)</b></td>", RegexOptions.Compiled);
        static private Regex eanDetailsTitleReg = new Regex(@"(?imns)<b>Titre</b></font></td>.*?<td colspan=""\d+?""><b>(?<title>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsAuthorReg = new Regex(@"(?imns)<b>Auteur</b>.+?<font color=""#(.){6}"">.+?</font></b></td>.*?<td width=""\d+%""><b>(?<author>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsEanCodeReg = new Regex(@"(?imns)<b>EAN13</b></font></td>.*?<font color=""#(.){6}"">.*?</font></b>.*?<b>(?<ean_code>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsPublisherReg = new Regex(@"(?imns)<b>Editeur</b>.*?<font color=""#(.){6}"">.*?<b>(<a href="".+?"">)?(?<publisher>.*?)(</a>)?</b>", RegexOptions.Compiled);
        static private Regex eanDetailsIsbnReg = new Regex(@"(?imns)<b>ISBN</b>.*?<font color=.*?<td><b>(&nbsp;)*?(?<isbn>\d*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsDistributorReg = new Regex(@"(?imns)<b>Distributeur</b>.*?<font color=.*?<b>(<a href="".+?"">)?(?<distributor>.*?)(</a>)?</b>", RegexOptions.Compiled);
        static private Regex eanDetailsDispoReg = new Regex(@"(?imns)<b>Dispo\.</b>.*?<font color=.*?<td><b>(?<dispo>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsWeightReg = new Regex(@"(?imns)<b>Poids</b>.*?<font color=.*?<table.*?<b>(?<weight>.*?)</b></td>", RegexOptions.Compiled);
        static private Regex eanDetailsScholarReg = new Regex(@"(?imns)(?<scholar>src=""img/scolaire4.gif""?)", RegexOptions.Compiled);
        static private Regex eanDetailsPriceReg = new Regex(@"(?imns)<b>TTC en Euros</b>.*?<font color=.*?<b>(?<price>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsPublishDateReg = new Regex(@"(?imns)<b>Date de parution</b>.*?<font color=.*?<b>(?<publish_date>.*?)</b>", RegexOptions.Compiled);
        static private Regex eanDetailsProviderRefReg = new Regex(@"(?imns)rence Fournisseur</b>.*?<font size=""2"">(?<provider_ref>.*?)</font>", RegexOptions.Compiled);
        static private Regex eanDetailsEndOfBusinessReg = new Regex(@"(?imns)<b>Fin Commercialisation</b>.*?<font size=""2"">(?<end_of_business>.*?)</font>", RegexOptions.Compiled);

        // returns the _gwId from the given HTML code
        public static String getGwIdFromHtml(String htmlCode)
        {
            try
            {
                Regex r = new Regex(@"_gwid=(?<_gwid>\w*)", RegexOptions.Compiled);
                Match m = r.Match(htmlCode);
                if (!m.Success)
                {
                    // On logue l'erreur
                    LogUtils.error("Erreur dans getGwIdFromHtml() : impossible de trouver l'expression r¨¦guli¨¨re dans le code HTML." +
                    "\n--------- DEBUT DU CODE HTML ---------\n" + htmlCode + " \n--------- FIN DU CODE HTML ---------");
                    return "";
                }

                return m.Result("${_gwid}");
            }
            catch (Exception regExpEx)
            {
                // On arrête tout et on met une erreur dans le status.
                LogUtils.error("Erreur d'expression r¨¦guli¨¨re lors du rafraichissement du GwID : " + regExpEx.Message);
                return "";
            }
        }

        // Returns an XmlDocument containing all the informations of #commandsCount Orders summaries taken from the HTML page
        // Structure of the Xml Document : 
        // <commandes>
        //      <commande>
        //          <destinataire>...</>
        //          <date_envoi>...</>
        //          <date_remise>...</>
        //          <reference>...</>
        //          <lignes>...</>
        //          <exemplaires>...</>
        //          <url_ref>...</>
        //      </>
        // </> 
        public static XmlDocument getOrdersListFromHtml(String htmlCode, int commandsCount)
        {
            XmlDocument response = new XmlDocument();
            XmlElement docRoot = response.CreateElement("commandes");
            response.AppendChild(docRoot);

            MatchCollection orders;

            // Create a new Regex object and define the regular expression.

            // Use the Matches method to find all matches in the input string.
            orders = orderListItemReg.Matches(htmlCode);

            LogUtils.debug(orders.Count + " orders found by the getOrdersListFromHtml regExp. Max Commands count = " + commandsCount);

            // Loop through the orders collection to retrieve all 
            // matches. For each match, get the orders details object and add it in the response document.
            for (int i = 0; (i < commandsCount) && (i < orders.Count); i++)
            {
                Match orderMatch = orders[i];

                LogUtils.debug("Enregistrement de l'order detail #" + i.ToString());

                // Convert the match String into an Xml Order
                XmlNode currentOrderNode = getOrderInfoFromHtml(orderMatch.Value, response);

                // Add the Xml order to the response XmlDocument
                docRoot.AppendChild(currentOrderNode);
            }

            return response;
        }

        // Returns an XmlElement containing the details of one order summary desrcibed in some HTML code
        // Called by getOrdersListFromHtml.
        // Needs the html code and the XmlDocument to create the XmlElement from.
        //      <commande>
        //          <destinataire>...</>
        //          <date_envoi>...</>
        //          <date_remise>...</>
        //          <reference>...</>
        //          <lignes>...</>
        //          <exemplaires>...</>
        //          <url_ref>...</>
        //      </>
        private static XmlElement getOrderInfoFromHtml(String htmlCode, XmlDocument xmlDoc)
        {

            XmlElement docRoot = xmlDoc.CreateElement("commande");

            Match result = orderInfoReg.Match(htmlCode);

            XmlElement destinataire = xmlDoc.CreateElement("destinataire");
            destinataire.InnerText = result.Result("${destinataire}");
            docRoot.AppendChild(destinataire);

            XmlElement date_envoi = xmlDoc.CreateElement("date_envoi");
            date_envoi.InnerText = formatDateString(result.Result("${date_envoi}").Replace("<br>", " - "));
            docRoot.AppendChild(date_envoi);

            XmlElement date_remise = xmlDoc.CreateElement("date_remise");
            date_remise.InnerText = formatDateString(result.Result("${date_remise}").Replace("<br>", " - "));
            docRoot.AppendChild(date_remise);

            XmlElement reference = xmlDoc.CreateElement("reference");
            reference.InnerText = result.Result("${reference}");
            docRoot.AppendChild(reference);

            XmlElement lignes = xmlDoc.CreateElement("lignes");
            lignes.InnerText = result.Result("${lignes}");
            docRoot.AppendChild(lignes);

            XmlElement exemplaires = xmlDoc.CreateElement("exemplaires");
            exemplaires.InnerText = result.Result("${exemplaires}");
            docRoot.AppendChild(exemplaires);

            XmlElement url_ref = xmlDoc.CreateElement("url_ref");
            url_ref.InnerText = result.Result("${url_ref}");
            docRoot.AppendChild(url_ref);


            return docRoot;
        }


        public static XmlNode getOrderDetailFromHtml(string htmlCode, XmlDocument doc)
        {
            XmlElement orderDetail = doc.CreateElement("commande");

            orderDetail.AppendChild(getOrderDetailHeaderFromHtml(htmlCode, doc));

            orderDetail.AppendChild(getOrderDetailLinesFromHtml(htmlCode, doc));

            return orderDetail;
        }


        // Returns an XmlElement containing the header of one order detail desrcibed in some HTML code
        // Called by getOrderDetailFromHtml.
        private static XmlElement getOrderDetailHeaderFromHtml(String htmlCode, XmlDocument xmlDoc)
        {

            XmlElement header = xmlDoc.CreateElement("entete");

            Regex orderDetailHeaderReg = new Regex("<b>:</b>(?<data>.*)</font>", RegexOptions.Compiled);

            Match result = orderDetailHeaderReg.Match(htmlCode);

            if (!result.Success)
            {
                LogUtils.error("Impossible to match the order detail header regexp");
                LogUtils.error("RegExp: " + orderDetailHeaderReg.ToString());
                LogUtils.error("HTML: " + htmlCode);

                return header;
            }

            XmlElement destinataire = xmlDoc.CreateElement("destinataire");
            destinataire.InnerText = result.Result("${data}").Trim();
            header.AppendChild(destinataire);
            result = result.NextMatch();

            XmlElement date_envoi = xmlDoc.CreateElement("date_envoi");
            date_envoi.InnerText = formatDateString(result.Result("${data}").Trim());
            header.AppendChild(date_envoi);
            result = result.NextMatch();

            XmlElement date_remise = xmlDoc.CreateElement("date_remise");
            date_remise.InnerText = formatDateString(result.Result("${data}").Trim());
            header.AppendChild(date_remise);
            result = result.NextMatch();

            XmlElement reference = xmlDoc.CreateElement("reference");
            reference.InnerText = result.Result("${data}").Trim().Replace("<font color=\"#B80738\">", "").Replace("</font>","");
            header.AppendChild(reference);
            result = result.NextMatch();

            XmlElement exp_mode = xmlDoc.CreateElement("mode_expedition");
            exp_mode.InnerText = result.Result("${data}").Trim();
            header.AppendChild(exp_mode);
            result = result.NextMatch();

            XmlElement ref_operation = xmlDoc.CreateElement("reference_operation");
            ref_operation.InnerText = result.Result("${data}").Trim();
            header.AppendChild(ref_operation);
 

            result = orderDetailSummaryReg.Match(htmlCode);

            if (!result.Success)
            {
                LogUtils.error("Impossible to match the order detail summary regexp");
                return header;
            }

            XmlElement item_quantity = xmlDoc.CreateElement("quantite_totale_commande");
            item_quantity.InnerText = result.Result("${item_quantity}").Trim();
            header.AppendChild(item_quantity);

            XmlElement sum = xmlDoc.CreateElement("prix_total_commande");
            sum.InnerText = result.Result("${sum}").Trim();
            header.AppendChild(sum);

            return header;
        }


        // Returns an XmlElement containing the lines of the command of one order detail described in some HTML code
        // Called by getOrderDetailFromHtml.
        private static XmlElement getOrderDetailLinesFromHtml(String htmlCode, XmlDocument xmlDoc)
        {
            XmlElement lines = xmlDoc.CreateElement("lignes");

            foreach (Match m in orderDetailListItemReg.Matches(htmlCode))
            {
                XmlElement line = xmlDoc.CreateElement("ligne");

                XmlElement ean_code = xmlDoc.CreateElement("code_ean");
                ean_code.InnerText = m.Result("${ean_code}").Trim();
                line.AppendChild(ean_code);

                XmlElement title = xmlDoc.CreateElement("titre");
                title.InnerText = m.Result("${title}").Trim();
                line.AppendChild(title);

                XmlElement publisher = xmlDoc.CreateElement("editeur");
                publisher.InnerText = m.Result("${publisher}").Trim();
                line.AppendChild(publisher);

                XmlElement price = xmlDoc.CreateElement("prix");
                price.InnerText = m.Result("${price}").Replace("Eu", "").Replace(',','.').Trim();
                line.AppendChild(price);

                XmlElement ref_line = xmlDoc.CreateElement("ref_ligne");
                ref_line.InnerText = m.Result("${ref_line}").Trim();
                line.AppendChild(ref_line);

                XmlElement quantity = xmlDoc.CreateElement("quantite");
                quantity.InnerText = m.Result("${quantity}").Trim();
                line.AppendChild(quantity);

                XmlElement line_price = xmlDoc.CreateElement("prix_ligne");
                line_price.InnerText = m.Result("${line_price}").Trim();
                line.AppendChild(line_price);

                // We add the line in the order detail lines list
                lines.AppendChild(line);
            }

            return lines;
        }

        public static XmlNode getEanDetailsFromHtml(string htmlCode, XmlDocument doc, String eanCode)
        {
            XmlElement eanDetail = doc.CreateElement("ouvrage");

            try{
                Match resultUpdateDate = eanDetailsUpdateDateReg.Match(htmlCode);
                if (!(resultUpdateDate).Success) {throw new Exception("Can't find Update Date");}
   
                Match resultTitle = eanDetailsTitleReg.Match(htmlCode);
                if (!(resultTitle).Success) {throw new Exception("Can't find Title");}

                Match resultAuthor = eanDetailsAuthorReg.Match(htmlCode);
                if (!(resultAuthor).Success) {throw new Exception("Can't find Author");}

                Match resultEanCode = eanDetailsEanCodeReg.Match(htmlCode);
                if (!(resultEanCode).Success) {throw new Exception("Can't find Ean Code");}

                Match resultPublisher = eanDetailsPublisherReg.Match(htmlCode);
                if (!(resultPublisher).Success) {throw new Exception("Can't find Publisher");}

                Match resultIsbn = eanDetailsIsbnReg.Match(htmlCode);
                if (!(resultIsbn).Success) {throw new Exception("Can't find ISBN");}

                Match resultDistributor = eanDetailsDistributorReg.Match(htmlCode);
                if (!(resultDistributor).Success) {throw new Exception("Can't find Distributor");}

                Match resultDispo = eanDetailsDispoReg.Match(htmlCode);
                if (!(resultDispo).Success) {throw new Exception("Can't find Dispo");}

                Match resultWeight = eanDetailsWeightReg.Match(htmlCode);
                if (!(resultWeight).Success) {throw new Exception("Can't find Weight");}

                Match resultScholar = eanDetailsScholarReg.Match(htmlCode);

                Match resultPrice = eanDetailsPriceReg.Match(htmlCode);
                if (!(resultPrice).Success) {throw new Exception("Can't find Price");}

                Match resultPublishDate = eanDetailsPublishDateReg.Match(htmlCode);
                if (!(resultPublishDate).Success) {throw new Exception("Can't find Publish Date");}

                Match resultProviderRef = eanDetailsProviderRefReg.Match(htmlCode);
                if (!(resultProviderRef).Success) {throw new Exception("Can't find Provider Ref");}

                Match resultEndOfBusiness = eanDetailsEndOfBusinessReg.Match(htmlCode);
                if (!(resultEndOfBusiness).Success) { throw new Exception("Can't find End Of Business Date"); }

                XmlNode title = doc.CreateElement("titre");
                title.InnerText = cleanHtmlText(resultTitle.Result("${title}"));
                eanDetail.AppendChild(title);

                XmlNode eanCodeNode = doc.CreateElement("code_ean");
                eanCodeNode.InnerText = cleanHtmlText(resultEanCode.Result("${ean_code}"));
                eanDetail.AppendChild(eanCodeNode);
                
                XmlNode author = doc.CreateElement("auteur");
                author.InnerText = cleanHtmlText(resultAuthor.Result("${author}"));
                eanDetail.AppendChild(author);

                XmlNode publisher = doc.CreateElement("editeur");
                publisher.InnerText = cleanHtmlText(resultPublisher.Result("${publisher}"));
                eanDetail.AppendChild(publisher);

                XmlNode distributor = doc.CreateElement("distributeur");
                distributor.InnerText = cleanHtmlText(resultDistributor.Result("${distributor}"));
                eanDetail.AppendChild(distributor);

                XmlNode poids = doc.CreateElement("poids");
                poids.InnerText = cleanHtmlText(resultWeight.Result("${weight}"));
                eanDetail.AppendChild(poids);

                XmlNode publish_date = doc.CreateElement("date_parution");
                publish_date.InnerText = cleanHtmlText(resultPublishDate.Result("${publish_date}"));
                eanDetail.AppendChild(publish_date);

                XmlNode update_date = doc.CreateElement("mise_a_jour");
                update_date.InnerText = cleanHtmlText(resultUpdateDate.Result("${update_date}"));
                eanDetail.AppendChild(update_date);

                XmlNode isbn = doc.CreateElement("isbn");
                isbn.InnerText = cleanHtmlText(resultIsbn.Result("${isbn}"));
                eanDetail.AppendChild(isbn);

                XmlNode dispo = doc.CreateElement("disponibilite");
                dispo.InnerText = cleanHtmlText(resultDispo.Result("${dispo}"));
                eanDetail.AppendChild(dispo);

                XmlNode price = doc.CreateElement("prix");
                price.InnerText = cleanHtmlText(cleanHtmlPriceText(resultPrice.Result("${price}")));
                eanDetail.AppendChild(price);

                XmlNode scholar = doc.CreateElement("scolaire");
                scholar.InnerText = (resultScholar.Success) ? "Oui" : "Non";
                eanDetail.AppendChild(scholar);

                XmlNode provider_ref = doc.CreateElement("ref_fournisseur");
                provider_ref.InnerText = cleanHtmlText(resultProviderRef.Result("${provider_ref}"));
                eanDetail.AppendChild(provider_ref);

                XmlNode end_of_business = doc.CreateElement("fin_commercialisation");
                end_of_business.InnerText = cleanHtmlText(resultEndOfBusiness.Result("${end_of_business}"));
                eanDetail.AppendChild(end_of_business);
             }
             catch (Exception e) // If there was an error during the extraction
             {
                 LogUtils.error("Impossible to match the ean detail regexp for EAN " + eanCode + ". Exception message : " + e.Message);

                XmlNode titleNode = doc.CreateElement("titre");
                titleNode.InnerText = "ERREUR LORS DE L'EXTRACTION. Contactez le responsable et lui fournir la r¨¦f¨¦rence EAN : "+eanCode;
                eanDetail.AppendChild(titleNode);

                XmlNode eanCodeNode = doc.CreateElement("code_ean");
                eanCodeNode.InnerText = eanCode;
                eanDetail.AppendChild(eanCodeNode);

                eanDetail.AppendChild(doc.CreateElement("auteur"));
                eanDetail.AppendChild(doc.CreateElement("editeur"));
                eanDetail.AppendChild(doc.CreateElement("distributeur"));
                eanDetail.AppendChild(doc.CreateElement("poids"));
                eanDetail.AppendChild(doc.CreateElement("date_parution"));
                eanDetail.AppendChild(doc.CreateElement("mise_a_jour"));
                eanDetail.AppendChild(doc.CreateElement("isbn"));
                eanDetail.AppendChild(doc.CreateElement("disponibilite"));
                eanDetail.AppendChild(doc.CreateElement("prix"));
                eanDetail.AppendChild(doc.CreateElement("scolaire"));
                eanDetail.AppendChild(doc.CreateElement("ref_fournisseur"));
                eanDetail.AppendChild(doc.CreateElement("fin_commercialisation"));
            }

            return eanDetail;
        }

        // The XmlDocument must be an ordersDetails, with the same schema 
        // as the one returned by DilicomBrowser.getOrdersDetails()
        public static String getCsvStringFromXmlDoc(XmlDocument doc)
        {
            String sep = Aide_Dilicom3.Properties.Settings.Default.CsvSeparator;
            String rep = Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement;

            XmlNode root = doc.DocumentElement;

            if (root.Name == "commandes")
            {
                return getOrdersDetailsCsvStringFromXmlDoc(doc, sep, rep);
            }
            else if (root.Name == "liste_ean")
            {
                return getEanDetailsCsvStringFromXmlDoc(doc, sep, rep);
            }
            else // If not one of the preceeding value...
            {
                return "Erreur lors de l'export en fichier CSV : document XML d'origine non valide";
            }
         
        }

        protected static String getOrdersDetailsCsvStringFromXmlDoc(XmlDocument doc, String sep, String rep)
        {
            

            // First line, contains the headers
            String csvString =
                "code_ean" + sep +
                "titre" + sep +
                "editeur" + sep +
                "prix" + sep +
                "ref_ligne" + sep +
                "quantite" + sep +
                "prix_ligne" + sep +
                "destinataire" + sep +
                "date_envoi" + sep +
                "date_remise" + sep +
                "reference" + sep +
                "mode_expedition" + sep +
                "reference_operation" + sep +
                "quantite_totale_commande" + sep +
                "prix_total_commande\n";

            XmlNode root = doc.DocumentElement;
            XmlNodeList commandes = root.SelectNodes("//commandes/commande");

            foreach (XmlNode commande in commandes)
            {
                XmlNode header = commande.SelectSingleNode("entete");

                String headerString = "";
                try
                {
                    headerString =
                        header.SelectSingleNode("destinataire").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("date_envoi").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("date_remise").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("reference").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("mode_expedition").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("reference_operation").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("quantite_totale_commande").InnerText.Replace(sep, rep) + sep +
                        header.SelectSingleNode("prix_total_commande").InnerText.Replace(sep, rep);
                }
                catch (Exception) // Catching exception : return String full of errors.
                {
                    headerString = "erreur" + sep + "erreur" + sep + "erreur" + sep + "erreur" + sep + "erreur" + sep + "erreur" + sep + "erreur" + sep + "erreur"; 
                }
 
                XmlNodeList lignes = commande.SelectNodes("lignes/ligne");

                foreach (XmlNode ligne in lignes)
                {
                    String ligneString =
                        ligne.SelectSingleNode("code_ean").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("titre").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("editeur").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("prix").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("ref_ligne").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("quantite").InnerText.Replace(sep, rep) + sep +
                        ligne.SelectSingleNode("prix_ligne").InnerText.Replace(sep, rep) + sep +
                        headerString + "\n";

                    csvString += ligneString;
                }

            }

            return csvString;

        }

        private static String getEanDetailsCsvStringFromXmlDoc(XmlDocument doc, String sep, String rep)
        {

            // First line, contains the headers
            String csvString =
                "titre" + sep +
                "code_ean" + sep +
                "auteur" + sep +
                "editeur" + sep +
                "distributeur" + sep +
                "poids" + sep +
                "date_parution" + sep +
                "mise_a_jour" + sep +
                "isbn" + sep +
                "disponibilite" + sep +
                "prix" + sep +
                "scolaire" + sep +
                "ref_fournisseur" + sep +
                "fin_commercialisation";

            string additionsValue = "";

            XmlNode root = doc.DocumentElement;
            XmlNodeList additions = root.SelectNodes("//liste_ean/ajout");

            // Preparing the additionnal informations
            foreach (XmlNode addition in additions)
            {
                csvString += sep + addition.SelectSingleNode("entete").InnerText.Replace(sep, rep);

                additionsValue += sep + addition.SelectSingleNode("valeur").InnerText.Replace(sep, rep);

            }

            // now that the header line is completed, we add the \n
            csvString += "\n";

            XmlNodeList books = root.SelectNodes("//liste_ean/ouvrage");

            // adding all the books info
            foreach (XmlNode book in books)
            {
                String bookString =

                book.SelectSingleNode("titre").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("code_ean").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("auteur").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("editeur").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("distributeur").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("poids").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("date_parution").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("mise_a_jour").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("isbn").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("disponibilite").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("prix").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("scolaire").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("ref_fournisseur").InnerText.Replace(sep, rep) + sep +
                    book.SelectSingleNode("fin_commercialisation").InnerText.Replace(sep, rep) +
                    additionsValue;

                csvString += bookString + "\n";
            }

            return csvString;
        }


        public static bool isEanCodeFound(string htmlCode)
        {
            Match eanCodeNotFound = eanCodeNotFoundReg.Match(htmlCode);

            return !eanCodeNotFound.Success;
        }


        public static bool isEanCodeValid(string htmlCode)
        {
            Match eanCodeNotValid = eanCodeNotValidReg.Match(htmlCode);

            return !eanCodeNotValid.Success;
        }

        private static String formatDateString(String dateString)
        {
            Match dateResult = formatDateReg.Match(dateString);

            if (!dateResult.Success)
            {
                LogUtils.error("Impossible to match the date " + dateString);
                return dateString;
            }


            return dateResult.Result("${day}") + "/" + dateResult.Result("${month}") + "/" + dateResult.Result("${year}");
            ;
        }


        public static List<String> getEanCodesFromFileNames(String [] fileNames)
        {
            List<String> eanCodes = new List<String>();

            MatchCollection codesMatches;

            String line = "";

            foreach (String fileName in fileNames) 
            {
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                
                while((line = file.ReadLine()) != null)
                {
                    codesMatches = eanCodeReg.Matches(line);

                    foreach (Match m in codesMatches)
                    {
                        String eanString = m.Result("${eanCode}");
                        LogUtils.debug("Found EAN Code " + eanString + " in file " + fileName);
                        eanCodes.Add(eanString);
                    }
                }

                file.Close();
            }

            return eanCodes;

        }

        private static String cleanHtmlText(string text)
        {
            return text.Replace("<b>", "").Replace("</b>", "").Replace("&nbsp;", " ").Trim();
        }

        // Converts ',' to '.' and remove _all_ spaces.
        private static String cleanHtmlPriceText(string price)
        {
            return price.Replace(",", ".").Replace(" ", "");
        }

    }

}
