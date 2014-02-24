using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aide_Dilicom3.Data
{
    /// <summary>
    /// Résumé d'une commande, i.e. ce qu'on peut en voir sur la page de suivi des commandes.
    /// </summary>
    public class ResumeCommande : Truc
    {
        public override string getKey()
        {
            return "resume_commande";
        }
    }
}
