using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;

namespace Aide_Dilicom3.Data
{
    /// <summary>
    ///  Un article avec toutes ses infos. Rempli grâce aux requêtes EAN.
    /// </summary>
    public class Article : Truc
    {
        public override string getKey()
        {
            return "article";
        }
    }
}
