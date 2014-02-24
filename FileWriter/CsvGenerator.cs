using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Data;
using System.IO;
using Aide_Dilicom3.Config;
using Aide_Dilicom3.Util;
using Aide_Dilicom3.Utils;
using System.Collections.Specialized;
using System.Xml.Serialization;

namespace Aide_Dilicom3.FileWriter
{
    public static class CsvGenerator
    {
        /// <summary>
        ///  Write a list of Truc to a CSV file. All the trucs must be of the same type.
        /// </summary>
        /// <param name="csvFile"></param>
        /// <param name="stuff"></param>
        public static void GenerateCsv(string csvFile, Truc[] stuff)
        {
            StringBuilder sb = new StringBuilder();

            String key = stuff[0].getKey();

            // Getting all possible columns
            List<String> Attributes = KeyUtils.getKeysWithoutName(XPath.getKeys(key), key);

            // Generating the header
            sb.AppendLine(getHeader(Attributes)+getAdditionalColumnHeader());

            String additionalColumnsValue = getAdditionalColumnValue();

            // For each stuff, generate the CSV line.
            foreach (Truc truc in stuff)
            {
                sb.Append(getCsvLine(truc, Attributes));
                sb.AppendLine(additionalColumnsValue);
            }

            File.WriteAllText(csvFile, sb.ToString());
        }


        private static string getCsvLine(Truc truc, List<string> Attributes)
        {
            if (Attributes.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(cleanString(truc.getValue(Attributes[0])));

            for (int i = 1; i < Attributes.Count; i++)
            {
                sb.Append(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator);
                sb.Append(cleanString(truc.getValue(Attributes[i])));
            }

            return sb.ToString();
        }

        /// <summary>
        ///  Replace all CSV separator in the string by the separator replacement
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string cleanString(string str)
        {
            return str.Replace(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator, Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement);
        }

        public static string getHeader(List<String> Attributes)
        {
            if (Attributes.Count == 0)
            {
                return "";
            }

            StringBuilder sb = new StringBuilder(Attributes[0]);

            for (int i = 1; i < Attributes.Count; i++)
            {
                sb.Append(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator);

                int index = Attributes[i].IndexOf(".");
                if (index < 0)
                {
                    sb.Append(Attributes[i].Replace(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator, Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement));
                }
                else
                {
                    sb.Append(Attributes[i].Substring(0, index).Replace(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator, Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement));
                }
            }

            return sb.ToString();
        }

        private static string getAdditionalColumnHeader()
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer s = new XmlSerializer(typeof(Param));

            foreach (String str in Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns)
            {
                Param p = (Param)s.Deserialize(new StringReader(str));
                if (p.enabled)
                {
                    sb.Append(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator);
                    sb.Append(p.name.Replace(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator, Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement));
                }
            }

            return sb.ToString();
        }

        private static string getAdditionalColumnValue()
        {
            StringBuilder sb = new StringBuilder();

            DateTime now = DateTime.Now;

            String date_token = Aide_Dilicom3.Properties.Settings.Default.DateToken;
            String time_token = Aide_Dilicom3.Properties.Settings.Default.TimeToken;
            String date_value = now.ToString(Aide_Dilicom3.Properties.Settings.Default.DateFormat);
            String time_value = now.ToString(Aide_Dilicom3.Properties.Settings.Default.TimeFormat);

            XmlSerializer s = new XmlSerializer(typeof(Param));

            foreach (String str in Aide_Dilicom3.Properties.Settings.Default.EanAdditionalColumns)
            {
                Param p = (Param)s.Deserialize(new StringReader(str));

                if (p.enabled)
                {
                    sb.Append(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator);
                    sb.Append(p.formula.Replace(date_token, date_value).Replace(time_token, time_value).Replace(Aide_Dilicom3.Properties.Settings.Default.CsvSeparator, Aide_Dilicom3.Properties.Settings.Default.CsvSeparatorReplacement));
                }
            }
            
            return sb.ToString();
        }

    }
}
