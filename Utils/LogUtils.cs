using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using System.IO;
using log4net.Repository.Hierarchy;
using System.Xml;
using System.Reflection;

namespace Aide_Dilicom3.Util
{
    /// <summary>
    /// This class is used to centralize all the logging related utility methods.
    /// 
    /// It is also acting as a wrapper around a default logger, 
    /// so that you can easily log some info without targetting any specific logger.
    /// </summary>
    public class LogUtils
    {
        private const string CHECK_FILENAME = "\\ppmsptemp.tmp";

        private const string LOG_CONFIG_FILE = "log.xml";

        private const string CONFIG_FOLDER = "Config";

        private const string DEFAULT_LOGGER_NAME = "root";


        static private ILog defaultLogger = null;

        /// <summary>
        /// Static constructor for initialzing log4net configuration.
        /// </summary>
        static LogUtils()
        {
            initLog();
            defaultLogger = LogManager.GetLogger(DEFAULT_LOGGER_NAME);
        }

        public static ILog getLogger(string logger)
        {
            return LogManager.GetLogger(logger);
        }

        public static void debug(object log)
        {
            defaultLogger.Debug(log);
        }

        public static void debug(object log, Exception e)
        {
            defaultLogger.Debug(log, e);
        }

        public static void info(object log)
        {
            defaultLogger.Info(log);
        }

        public static void info(object log, Exception e)
        {
            defaultLogger.Info(log, e);
        }

        public static void warn(object log)
        {
            defaultLogger.Warn(log);
        }

        public static void warn(object log, Exception e)
        {
            defaultLogger.Warn(log, e);
        }

        public static void error(object log)
        {
            defaultLogger.Error(log);
        }

        public static void error(object log, Exception e)
        {
            defaultLogger.Error(log, e);
        }

        public static void fatal(object log)
        {
            defaultLogger.Fatal(log);
        }

        public static void fatal(object log, Exception e)
        {
            defaultLogger.Fatal(log, e);
        }


        /// <summary>
        /// Checks whether the folder given in parameter can be written to.
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static bool isFolderWritable(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                string filePath = folderPath + CHECK_FILENAME;
                return isFileWritable(filePath);
            }
            return false;
        }


        /// <summary>
        ///    Checks whether we have write access to the given file.
        ///    
        /// WARNING: THE FILE, IF ALREADY EXISTING, WILL BE DELETED IN THE PROCESS
        /// </summary>
        /// <param name="filePath"> Full path to the file.</param>
        /// <returns></returns>
        public static bool isFileWritable(string filePath)
        {
            try
            {
                // Delete file if it was existing.
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Create temp file and write to it.
                using (FileStream fs = new FileStream(filePath, FileMode.CreateNew, FileAccess.Write))
                {
                    fs.WriteByte(0xff);
                }

                // Delete temp file if it was existing.
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true; // If we reach here, means everything went fine !!
                }
            }
            catch
            {
                // Something bad happened...
                return false;
            }

            return false;

        }

        public static void initLog()
        {
            string currentAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            if (currentAssemblyDirectory.StartsWith("file:\\"))
            {
                currentAssemblyDirectory = currentAssemblyDirectory.Substring(6);
            }

            FileInfo fi = new FileInfo(currentAssemblyDirectory
                + Path.DirectorySeparatorChar
                + CONFIG_FOLDER
                + Path.DirectorySeparatorChar
                + LOG_CONFIG_FILE);

            XmlConfigurator.Configure(fi);

            /*
                // Read XML Config file from resources
                Assembly ThisAssembly = Assembly.GetExecutingAssembly();
                System.IO.Stream logConfigFileStream = ThisAssembly.GetManifestResourceStream(LOG_CONFIG_PATH);
                StreamReader stIn = new StreamReader(logConfigFileStream);
                string xmlConfigStr = stIn.ReadToEnd();

                // Load config
                XmlDocument configXml = new XmlDocument();
                configXml.LoadXml(xmlConfigStr);
            configXml.Load(
                XmlConfigurator.Configure(configXml.DocumentElement); */

        }
    }
}
