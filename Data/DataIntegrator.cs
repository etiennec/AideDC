using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Network;
using System.Collections.Specialized;
using System.Xml;
using System.Windows.Forms;
using System.ComponentModel;
using Aide_Dilicom3.Parsing;

namespace Aide_Dilicom3.Data
{
    /// <summary>
    /// This utility class will take care of calling the sub-pages when the data (commands for example) are distributed 
    /// over more than one page.
    /// 
    /// It will also invoke all the parsing tasks.
    /// 
    /// It is the entry point for retrieving business objects.
    /// </summary>
    public static class DataIntegrator
    {
        public static void getEanDetailsAsync(List<string> eanCodes, RunWorkerCompletedEventHandler workFinishedEventHandler, ProgressChangedEventHandler progressReportedEventHandler)
        {
            BackgroundWorker eanGetterWorker = new BackgroundWorker();

            eanGetterWorker.WorkerReportsProgress = true;
            eanGetterWorker.WorkerSupportsCancellation = false;

            eanGetterWorker.ProgressChanged += progressReportedEventHandler;
            eanGetterWorker.RunWorkerCompleted += workFinishedEventHandler;
            eanGetterWorker.DoWork += new DoWorkEventHandler(eanGetterWorker_DoWork);

            eanGetterWorker.RunWorkerAsync(eanCodes);
        }

        private static void eanGetterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<string> eanCodes = (List<string>)e.Argument;

            List<Article> results = new List<Article>();

            int done = 0;

            // We create a cache of all Articles in order not to load two times the same article (that actually doesn't work...)
            Dictionary<String, Article> articlesMap = new Dictionary<String, Article>();

            foreach (string eanCode in eanCodes)
            {
                Article art = null;

                if (articlesMap.ContainsKey(eanCode))
                {
                    art = articlesMap[eanCode];
                }
                else
                {
                    // Prepare parameter of EAN
                    StringDictionary param = new StringDictionary();
                    param.Add(NetworkConstants.PARAM_EAN_EAN, eanCode);

                    //Send request to the EAN Query page
                    XmlDocument doc = NetworkInterface.retrieve(NetworkInterface.RequestType.EAN_DETAILS, param);

                    art = Parsing.ArticleParser.parseEanDetailsResponse(doc);
                    articlesMap.Add(eanCode, art);
                }
                
                results.Add(art);

                ++done;
                worker.ReportProgress(done * 100 / eanCodes.Count);
            }

            e.Result = results;
        }

        public static void getCommandsListAsync(int CommandsCount, RunWorkerCompletedEventHandler runWorkerCompletedEventHandler)
        {
            BackgroundWorker commandsListGetterWorker = new BackgroundWorker();

            commandsListGetterWorker.WorkerReportsProgress = false;
            commandsListGetterWorker.WorkerSupportsCancellation = false;

            commandsListGetterWorker.RunWorkerCompleted += runWorkerCompletedEventHandler;
            commandsListGetterWorker.DoWork += new DoWorkEventHandler(commandsListGetterWorker_DoWork);

            commandsListGetterWorker.RunWorkerAsync(CommandsCount);
        }

        private static void commandsListGetterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int CommandsCount = (int)e.Argument;

            List<ResumeCommande> results = new List<ResumeCommande>();

            int pageIndex = 1;

            while (CommandsCount > 0)
            {
                // Prepare parameter of EAN
                StringDictionary param = new StringDictionary();
                param.Add(NetworkConstants.PARAM_LIST_PAGE, pageIndex.ToString());

                //Send request to the EAN Query page
                XmlDocument doc = NetworkInterface.retrieve(NetworkInterface.RequestType.COMMANDS_LIST, param);

                results.AddRange(Parsing.ResumeCommandeParser.parseCommandsListResponse(doc, (CommandsCount > 20 ? 20 : CommandsCount)));

                ++pageIndex;

                CommandsCount -= 20;
            }

            e.Result = results;
        }

        public static void getCommandsDetailsAsync(List<string> urlRefs, RunWorkerCompletedEventHandler runWorkerCompletedEventHandler, ProgressChangedEventHandler progressChangedEventHandler)
        {
            BackgroundWorker commandsDetailsGetterWorker = new BackgroundWorker();

            commandsDetailsGetterWorker.WorkerReportsProgress = true;
            commandsDetailsGetterWorker.WorkerSupportsCancellation = false;

            commandsDetailsGetterWorker.ProgressChanged += progressChangedEventHandler;
            commandsDetailsGetterWorker.RunWorkerCompleted += runWorkerCompletedEventHandler;
            commandsDetailsGetterWorker.DoWork += new DoWorkEventHandler(commandsDetailsGetterWorker_DoWork);

            commandsDetailsGetterWorker.RunWorkerAsync(urlRefs);
        }

        private static void commandsDetailsGetterWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            List<string> urlRefs = (List<string>)e.Argument;

            List<Ligne> results = new List<Ligne>();

            int done = 0;

            foreach (string url in urlRefs) 
            {
                // TODO retrieve the page
                StringDictionary sd = new StringDictionary();
                sd.Add("url", url);
                XmlDocument doc = NetworkInterface.retrieve(NetworkInterface.RequestType.COMMAND_DETAIL, sd);

                results.AddRange(DetailCommandeParser.parseCommandDetails(doc));

                int page = 1; // Number of the page from the command details we're looking at.

                while (ParsingUtils.exist("detection_detail_commande_pages_restantes", doc))
                {
                    ++page;
                    sd = new StringDictionary();
                    sd.Add("url", url);
                    sd.Add("p", page.ToString());
                    doc = NetworkInterface.retrieve(NetworkInterface.RequestType.COMMAND_DETAIL, sd);
                    results.AddRange(DetailCommandeParser.parseCommandDetails(doc));
                }

                // This command is over, we update the progress bar.
                ++done;
                worker.ReportProgress(done * 100 / urlRefs.Count);
            }

            e.Result = results;
        }
    }
}
