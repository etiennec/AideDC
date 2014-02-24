using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace Aide_Dilicom3.Util
{

    /// <summary>
    ///  Loads address & XPaths
    /// </summary>
    class PropertiesResourceManager
    {
        private const string PROPERTIES_FILE_EXTENSION = "txt";

        private const string KEY_VALUE_DELIMITER = "=";

        private const string COMMENT_CHAR = "#";

        private const string CONFIG_FOLDER = "Config";

        private string baseName;


        // Resources
        private Dictionary<string, string> resources = new Dictionary<string, string>();

        private Dictionary<string, List<string>> keysDictionary = new Dictionary<string, List<string>>();

        /// <summary>
        ///   Create a new Properties Resource manager, that will load properties from the files named
        ///   baseName.txt, located in the Config folder of the assembly.
        /// </summary>
        /// <param name="baseName"></param>
        public PropertiesResourceManager(string baseName)
        {
            this.baseName = baseName;

            // Loading all data from the file.
            loadFile();
        }

        /// <summary>
        ///    Returns the string value.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string getString(string key)
        {
            string value = null;

            resources.TryGetValue(key, out value);
            return value; // Null if the key was not found in the default language;
        }

        public List<string> getKeys(string key)
        {
            if (keysDictionary.ContainsKey(key))
            {
                return keysDictionary[key];
            }
            else
            {
                List<string> keys = new List<string>();

                foreach (string reskey in resources.Keys)
                {
                    if (reskey.StartsWith(key))
                    {
                        keys.Add(reskey);
                    }
                }
                keysDictionary.Add(key, keys);
                return keys;
            }
        }

        // 
        /// <summary>
        /// 
        /// Loading the given locale file.
        /// Adds it to the list of loaded locales. 
        /// 
        /// Returns the Dictionary with the resources linked to this language.
        /// 
        /// </summary>
        /// <param name="locale"></param>
        /// <returns></returns>
        private Dictionary<string, string> loadFile()
        {
            string fileName = baseName + "." + PROPERTIES_FILE_EXTENSION;

            string currentAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

            if (currentAssemblyDirectory.StartsWith("file:\\"))
            {
                currentAssemblyDirectory = currentAssemblyDirectory.Substring(6);
            }

            FileInfo fi = new FileInfo(currentAssemblyDirectory
                + Path.DirectorySeparatorChar
                + CONFIG_FOLDER
                + Path.DirectorySeparatorChar
                + fileName);

            LogUtils.debug("Will now search for resource file " + fi.FullName);

            if (!fi.Exists) // If we can't file an exact file match
            {

                LogUtils.error("Couldn't locate root resource file " + fileName);
                throw new Exception("Couldn't locate root resource file " + fileName);
            }

            // We have a file, let's create a dictionary and fill it !
            LogUtils.debug("File found, will be loaded: " + fi.FullName);
            resources = getFileContents(fi);
            return resources;
        }

        /// <summary>
        /// Open the given file, fills all the key/value pairs it contains in a dictionary and returns the dictionary.
        /// 
        /// We suppose the file exists and contains valid key/value pairs
        /// </summary>
        /// <param name="fi"></param>
        /// <returns></returns>

        private Dictionary<string, string> getFileContents(FileInfo fi)
        {
            Dictionary<string, string> resourceManager = new Dictionary<string, string>();

            string[] lines = File.ReadAllLines(fi.FullName);

            foreach (string line in lines)
            {
                int delimiterIndex = line.IndexOf(KEY_VALUE_DELIMITER);
                // We ignore comments and non key-pair lines
                if (delimiterIndex > 0 && !line.Trim().StartsWith(COMMENT_CHAR))
                {
                    string key = line.Substring(0, delimiterIndex);
                    string value = line.Substring(delimiterIndex + 1);
                    //value = value.Replace(@"\r\n", Environment.NewLine);
                    //value = value.Replace(@"\n", Environment.NewLine);
                    //value = value.Replace("\\\"", "\""); // Replace \" by "
                    int unicodeEscapeIndex = value.IndexOf(@"\u");
                    while (unicodeEscapeIndex >= 0)
                    {
                        string unicodeValue = value.Substring(unicodeEscapeIndex + 2, 4);
                        value = value.Replace(@"\u" + unicodeValue, ((char)int.Parse(unicodeValue, NumberStyles.HexNumber)).ToString());
                        unicodeEscapeIndex = value.IndexOf(@"\u");
                    }
                    resourceManager.Add(key, value);
                }
            }
            return resourceManager;
        }
    }
}
