using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aide_Dilicom3.Util;

namespace Aide_Dilicom3.Config
{
    public static class Address
    {
        private static PropertiesResourceManager AddressManager = null;

        static Address()
        {
            AddressManager = new PropertiesResourceManager("Adresses");
        }

        public static string get(string key)
        {
            return AddressManager.getString(key);
        }
    }
}
