/* 
 * Aide Dilicom
 * Logiciel d'aide ?la gestion des commandes sur le site Dilicom.
 * Version : 0.1a
 * 13 Janvier 2007
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections;
using Aide_Dilicom3.Network;
using Aide_Dilicom3.Util;
using Aide_Dilicom3.Utils;
using Aide_Dilicom3.Data;
using Aide_Dilicom3.FileWriter;
using System.Collections.Specialized;
using Aide_Dilicom3.Config;
using System.Xml.Serialization;

namespace Aide_Dilicom3.Forms
{
    public partial class DilicomForm : Form
    {
        public DilicomForm()
        {
            InitializeComponent();
            NetworkInterface.Browser = MyWebBrowser;

            

            // Initial connection to Dilicom.
            setOpsTabsEnableStatus(false);
            MainTabs.SelectTab(NavigoTab);
            startConnect();
        }

        private void setOpsTabsEnableStatus(bool state)
        {
            (this.RapidInfoTab as Control).Enabled = state;
            (this.CommandesTab as Control).Enabled = state;
        }


        /// <summary>
        /// Async connection to Dilcom web site. Just starts the connection operation.
        /// </summary>
        private void startConnect()
        {
            BackgroundWorker connectWorker = new BackgroundWorker();

            connectWorker.WorkerReportsProgress = false;
            connectWorker.WorkerSupportsCancellation = false;

            connectWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(connectWorker_RunWorkerCompleted);
            connectWorker.DoWork += new DoWorkEventHandler(connectWorker_DoWork);

            connectWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Re-enable disabled tabs once the connection is established.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void connectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            setOpsTabsEnableStatus(true);
        }

        /// <summary>
        /// Connect to dilicom (on startup)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void connectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            NetworkInterface.retrieve(NetworkInterface.RequestType.CONNEXION, null);
        }

        private void FillAdditionalColumns()
        {

            if (Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns == null)
            {
                Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns = new StringCollection();
            }

            XmlSerializer s = new XmlSerializer(typeof(Param));

            foreach (String str in Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns)
            {
                Param p = (Param)s.Deserialize(new StringReader(str));

                object[] tuple = { p.name, p.formula, p.enabled };

                EanAdditionalFieldsDS.Tables[0].LoadDataRow(tuple, LoadOption.OverwriteChanges);
            }
        }


        private void ApplicationLoad(object sender, EventArgs e)
        {
            LogUtils.debug("Demarrage de l'application...");

            CommandsCount.Value = Aide_Dilicom3.Properties.Settings.Default.CommandCount;

            FillAdditionalColumns();

            LoadSettings();

            LogUtils.debug("Application d¨¦marr¨¦e");
        }

        private void LoadSettings()
        {
            textLogin.Text = Aide_Dilicom3.Properties.Settings.Default.Login;
            textPassword.Text = Aide_Dilicom3.Properties.Settings.Default.Password;
            textWebBaseUrl.Text = Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl;
            textCsvSeparator.Text = Aide_Dilicom3.Properties.Settings.Default.CsvSeparator;
            textCsvReplacement.Text = Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement;
            timeoutSelector.Value = (decimal)Aide_Dilicom3.Properties.Settings.Default.Timeout;
        }


        private void registerHandlers()
        {
            // Registering the methods in the Event Handlers
            /*db.BeginRefreshSession += new EventHandler(disableUI);
            db.EndRefreshSession += new EventHandler(enableUI);

            db.BeginGetOrdersList += new EventHandler(disableUI);
            db.EndGetOrdersList += new EventHandler(populateOrdersList);
            db.EndGetOrdersList += new EventHandler(enableUI);

            db.BeginGetOrdersDetails += new EventHandler(disableUI);
            db.EndGetOrdersDetails += new EventHandler(enableUI);

            db.BeginGetEanDetails += new EventHandler(disableUI);
            db.EndGetEanDetails += new EventHandler(enableUI);

            db.GotSingleOrderDetails += new EventHandler(updateExportProgressBar);
            db.GotSingleEanDetails += new EventHandler(updateEanExportProgressBar);

            db.ResetCompleted += new EventHandler(enableUI);*/
        }

        private void RefreshGwIdButton_Click(object sender, EventArgs e)
        {
            //DilicomBrowser.getInstance().doRefreshGwId();
        }

        private void RefreshCommandsButton_Click(object sender, EventArgs e)
        {
            Data.DataIntegrator.getCommandsListAsync((int)CommandsCount.Value, new RunWorkerCompletedEventHandler(displayCommandsList));
        }

        private void ApplicationClosed(object sender, FormClosedEventArgs e)
        {
            LogUtils.debug("Application ferm¨¦e");
        }

        private void ResetAllButton_Click(object sender, EventArgs e)
        {
            LogUtils.debug("Red¨¦arrage de l'application...");

            //dilicomWebBrowser.Stop();

            //DilicomBrowser.getInstance().reset();

            registerHandlers();

            LogUtils.debug("Application red¨¦marr¨¦e");
        }


        private void ExportCsvButton_Click(object sender, EventArgs e)
        {
            saveCsvFile.InitialDirectory = FileUtils.getFolderPathFromFilePath(Aide_Dilicom3.Properties.Settings.Default.ExportCommandCsvFile);
            saveCsvFile.FileName = FileUtils.getFileNameFromFilePath(Aide_Dilicom3.Properties.Settings.Default.ExportCommandCsvFile);

            List<String> urlRefs = new List<string>();

            DataTable t = OrdersListDS.Tables["commande"];
            foreach (DataRow dr in t.Rows)
            {
                if ((Boolean)dr["isSelected"])
                {
                    urlRefs.Add((String)dr["url_ref"]);
                }
            }

            DataIntegrator.getCommandsDetailsAsync(urlRefs, new RunWorkerCompletedEventHandler(exportCommandsCsvDocument), new ProgressChangedEventHandler(updateCommandsExportProgressBar));

        }


        private void reloadConfigButton_Click(object sender, EventArgs e)
        {
            //AideDilicomXmlSettings.getInstance().readXmlParameters();
        }


        // Disable the refresh session Button and display a waiting text next to it.
        private delegate void disableUIDelegate(object sender, EventArgs e);
        private void disableUI(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                disableUIDelegate deleg = new disableUIDelegate(disableUI);
                this.Invoke(deleg, args);
            }
            else
            {
                RefreshCommandsButton.Enabled = false;
                ExportCsvButton.Enabled = false;
                EanExportCSVButton.Enabled = false;
                importEanButton.Enabled = false;
                deleteEanButton.Enabled = false;
            }
        }

        // Enable the refresh session Button and display an "alright" text next to it.
        private delegate void enableUIDelegate(object sender, EventArgs e);
        private void enableUI(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                enableUIDelegate deleg = new enableUIDelegate(enableUI);
                this.Invoke(deleg, args);
            }
            else
            {
                RefreshCommandsButton.Enabled = true;
                ExportCsvButton.Enabled = true;
                EanExportCSVButton.Enabled = true;
                importEanButton.Enabled = true;
                deleteEanButton.Enabled = true;
            }

        }


        // Updates the value of the Orders details progress Bar
        private delegate void updateExportProgressBarDelegate(object sender, EventArgs e);
        private void updateExportProgressBar(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                enableUIDelegate deleg = new enableUIDelegate(updateExportProgressBar);
                this.Invoke(deleg, args);
            }
            else
            {
                int percentage = ((NetworkInterface.ProgressIndicatorEventArgs)e).getPercentage();
                OrdersExportProgressBar.Value = percentage;
                OrdersExportProgressBar.Refresh();
            }

        }


        // Updates the value of the EAN details progress Bar
        private delegate void updateEanExportProgressBarDelegate(object sender, ProgressChangedEventArgs e);
        private void updateEanExportProgressBar(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                updateEanExportProgressBarDelegate deleg = new updateEanExportProgressBarDelegate(updateEanExportProgressBar);
                this.Invoke(deleg, args);
            }
            else
            {
                EanExportProgressBar.Value = e.ProgressPercentage;
                EanExportProgressBar.Refresh();
            }

        }


        // Updates the value of the Commandes csv export details progress Bar
        private delegate void updateCommandsExportProgressBarDelegate(object sender, ProgressChangedEventArgs e);
        private void updateCommandsExportProgressBar(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                updateCommandsExportProgressBarDelegate deleg = new updateCommandsExportProgressBarDelegate(updateCommandsExportProgressBar);
                this.Invoke(deleg, args);
            }
            else
            {
                OrdersExportProgressBar.Value = e.ProgressPercentage;
                OrdersExportProgressBar.Refresh();
            }

        }



        // Export the Commands (lines) as CVS document
        private delegate void exportCommandsCsvDocumentDelegate(object sender, RunWorkerCompletedEventArgs e);
        private void exportCommandsCsvDocument(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                exportCommandsCsvDocumentDelegate deleg = new exportCommandsCsvDocumentDelegate(exportCommandsCsvDocument);
                this.Invoke(deleg, args);
            }
            else
            {
                if (e.Error != null)
                {
                    LogUtils.error(e.Error);
                    MessageBox.Show("Une erreur est survenue : " + e.Error.Message);
                    return;
                }

                DialogResult dr = saveCsvFile.ShowDialog();

                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                // Saving the file name for later
                Aide_Dilicom3.Properties.Settings.Default.ExportCommandCsvFile = saveCsvFile.FileName;
                Aide_Dilicom3.Properties.Settings.Default.Save();

                List<Ligne> results = (List<Ligne>)e.Result;

                CsvGenerator.GenerateCsv(saveCsvFile.FileName, results.ToArray());
            }
        }


        // Export the Articles as CVS document
        private delegate void exportEanCsvDocumentDelegate(object sender, RunWorkerCompletedEventArgs e);
        private void exportEanCsvDocument(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                exportEanCsvDocumentDelegate deleg = new exportEanCsvDocumentDelegate(exportEanCsvDocument);
                this.Invoke(deleg, args);
            }
            else
            {
                if (e.Error != null)
                {
                    LogUtils.error(e.Error);
                    MessageBox.Show("Une erreur est survenue : " + e.Error.Message);
                    return;
                }

                DialogResult dr = saveCsvFile.ShowDialog();

                if (dr == DialogResult.Cancel)
                {
                    return;
                }

                // Saving the file name for later
                Aide_Dilicom3.Properties.Settings.Default.ExportEanCsvFile = saveCsvFile.FileName;
                Aide_Dilicom3.Properties.Settings.Default.Save();

                List<Article> results = (List<Article>)e.Result;

                CsvGenerator.GenerateCsv(saveCsvFile.FileName, results.ToArray());
            }
        }



        // Display the list of commands in the commands list
        private delegate void displayCommandsListDelegate(object sender, RunWorkerCompletedEventArgs e);
        private void displayCommandsList(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                object[] args = new object[2];
                args[0] = sender;
                args[1] = e;
                displayCommandsListDelegate deleg = new displayCommandsListDelegate(displayCommandsList);
                this.Invoke(deleg, args);
            }
            else
            {
                if (e.Error != null)
                {
                    LogUtils.error(e.Error);
                    MessageBox.Show("Une erreur est survenue : " + e.Error.Message);
                    return;
                }

                List<ResumeCommande> results = (List<ResumeCommande>)e.Result;

                FillCommandList(results);
            }

        }

        private void FillCommandList(List<ResumeCommande> results)
        {
            // Deleting all resume_commandes
            OrdersListDS.Tables["commande"].Clear();

            OrdersListDS.Tables["commande"].BeginLoadData();

            foreach (ResumeCommande commande in results)
            {
                object[] tuple = { commande.data["Destinataire"], commande.data["Remise_le.date"], commande.data["Traitee_le.date"], commande.data["Reference"], commande.data["Lignes"], commande.data["Exemplaires"], commande.data["Lien_detail"], true };

                OrdersListDS.Tables["commande"].LoadDataRow(tuple, LoadOption.OverwriteChanges);
            }

            OrdersListDS.Tables["commande"].EndLoadData();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridViewRow newRow = EanListGridView.Rows.SharedRow(e.RowIndex);
            Object cellContent = newRow.Cells[1].Value;

            if (cellContent == System.DBNull.Value)
            {
                // We do nothing, the empty value will be automatically deleted.
                return;
            }
            e.Cancel = true;
            System.Windows.Forms.MessageBox.Show("Erreur, ce code EAN existe déj?dans la liste.\n(Appuyez sur 'Echap' pour annuler)");
        }

        private void importEanButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openEanFile.ShowDialog();

            // We cancel if the user cancels
            if (result == DialogResult.Cancel)
            {
                return;
            }

            String[] eanFileNames = openEanFile.FileNames;

            List<String> eanCodes = DilicomUtils.getEanCodesFromFileNames(eanFileNames);

            DataTable t = EanListDS.Tables["EanList"];
            foreach (string eanCode in eanCodes)
            {
                try
                {
                    t.LoadDataRow(new Object[] { eanCode, null }, LoadOption.OverwriteChanges);
                }
                catch (ConstraintException)
                {
                    // EAN already exists : Do nothing...
                }
            }

        }


        private void EanListGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow newRow = EanListGridView.Rows.SharedRow(e.RowIndex);
            Object cellContent = newRow.Cells[1].Value;
            if ((cellContent == System.DBNull.Value) || (cellContent == null) || (cellContent.ToString() == ""))
            {
                return;
            }
            String eanString = (String)cellContent;


            // First, checking that EAN is 13 digits long
            if (eanString.Length != 13)
            {
                System.Windows.Forms.MessageBox.Show("Erreur : le code EAN doit faire exactement 13 chiffres.\n(Appuyez sur 'Echap' pour annuler)");
                e.Cancel = true;
                return;
            }


            // Then, checking there is no characters...
            long eanInt = -1;
            try
            {
                eanInt = Int64.Parse(eanString);
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Erreur : le code EAN est compos?uniquement de chiffres.\n(Appuyez sur 'Echap' pour annuler)");
                e.Cancel = true;
                return;
            }

            // Finally, checking that EAN is positive
            if (eanInt < 0)
            {
                System.Windows.Forms.MessageBox.Show("Erreur : le code EAN ne peut pas être négatif !.\n(Appuyez sur 'Echap' pour annuler)");
                e.Cancel = true;
                return;
            }


        }


        private void EanExportCSVButton_Click(object sender, EventArgs e)
        {
            saveCsvFile.InitialDirectory = FileUtils.getFolderPathFromFilePath(Aide_Dilicom3.Properties.Settings.Default.ExportEanCsvFile);
            saveCsvFile.FileName = FileUtils.getFileNameFromFilePath(Aide_Dilicom3.Properties.Settings.Default.ExportEanCsvFile);

            List<String> eanList = new List<string>();

            DataTable t = EanListDS.Tables["EanList"];
            foreach (DataRow dr in t.Rows)
            {
                if ((Boolean)dr["isEanSelected"])
                {
                    eanList.Add((String)dr["EanCode"]);
                }
            }

            Data.DataIntegrator.getEanDetailsAsync(eanList, new RunWorkerCompletedEventHandler(exportEanCsvDocument), new ProgressChangedEventHandler(updateEanExportProgressBar));
        }

        private void deleteEanButton_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.MessageBox.Show("Etes vous sur de vouloir supprimer tous les codes EAN ?", "Suppression",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         == DialogResult.Yes)
            {
                EanListDS.Clear();
                EanListGridView.Refresh();
            }
        }

        /// <summary>
        ///  After every successful validation of additional fields table, we save the contents to the user settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Validated(object sender, EventArgs e)
        {
            StringCollection sc = new StringCollection();

            Param p = new Param();
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(Param));

            foreach (DataRow row in EanAdditionalFieldsDS.Tables[0].Rows)
            {
                p = new Param();
                try
                {
                    p.name = (string)row.ItemArray[0];
                    p.formula = (string)row.ItemArray[1];
                    try
                    {
                        p.enabled = (bool)row.ItemArray[2];
                    }
                    catch (InvalidCastException)
                    {
                        p.enabled = false;
                    }

                    TextWriter w = new StringWriter();
                    x.Serialize(w, p);

                    sc.Add(w.ToString());
                    w.Close();
                }
                catch (Exception)
                { // We don't do anything and skip this record. Might as well have been deleted.
                }
            }

            Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns = sc;

            Aide_Dilicom3.Properties.Settings.Default.Save();
        }

        private void saveSettings(object sender, EventArgs e)
        {
            Aide_Dilicom3.Properties.Settings.Default.Login = textLogin.Text;
            Aide_Dilicom3.Properties.Settings.Default.Password = textPassword.Text;
            Aide_Dilicom3.Properties.Settings.Default.WebSiteBaseUrl = textWebBaseUrl.Text;
            Aide_Dilicom3.Properties.Settings.Default.CsvSeparator = textCsvSeparator.Text;
            Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement = textCsvReplacement.Text;
            Aide_Dilicom3.Properties.Settings.Default.Timeout = (int)timeoutSelector.Value;

            Aide_Dilicom3.Properties.Settings.Default.Save();
        }

        private void textWebBaseUrl_Validating(object sender, CancelEventArgs e)
        {
            textWebBaseUrl.Text = WebUtils.getCleansedUrl(textWebBaseUrl.Text);
        }

        private void CommandsCount_Leave(object sender, EventArgs e)
        {
            Aide_Dilicom3.Properties.Settings.Default.CommandCount = (int)CommandsCount.Value;
            Aide_Dilicom3.Properties.Settings.Default.Save();
        }

        private void MyWebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            UrlText.Text = e.Url.ToString();
        }

        private void MyWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            UrlText.Text = e.Url.ToString();
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            MyWebBrowser.Navigate(UrlText.Text);
        }


    }
}