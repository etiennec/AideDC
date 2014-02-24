using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Aide_Dilicom3.Data
{
    /// <summary>
    /// Base class for any item
    /// </summary>
    public abstract class Truc
    {
        /// <summary>
        /// To overwrite in children classes
        /// </summary>
        public abstract string getKey();

        public StringDictionary data = new StringDictionary();

        public string getValue(string key)
        {
            if (data.ContainsKey(key))
                return data[key];
            else
                return "";
        }
    }
}
