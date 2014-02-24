using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Data
{
    /// <summary>
    /// Une ligne dans une commande (= un ouvrage en 1 ou plusieurs exemplaires, avec le prix,la quantité, les infos, etc.).
    /// La ligne comprend aussi les informations de la commande (nécéssaire pour l'export).
    /// </summary>
    public class Ligne : Truc
    {
        public override string getKey()
        {
            return "ligne";
        }
    }
}
