using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    internal class Personnel
    {
        private string matricule;
        private DateTime dateEmbauche;
        private string motDePasse;
        private int type;
        private int materielId;

        public Personnel(string matricule, DateTime dateEmbauche, string motDePasse, int type, int materielId)
        {
            this.matricule = matricule;
            this.dateEmbauche = dateEmbauche;
            this.motDePasse = motDePasse;
            this.type = type;
            this.materielId = materielId;
        }
    }
}
