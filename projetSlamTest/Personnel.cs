using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Personnel
    {

        public Personnel(string matricule, DateTime dateEmbauche, string motDePasse, int type, int materielId)
        {
            Matricule = matricule;
            DateEmbauche = dateEmbauche;
            MotDePasse = motDePasse;
            Type = type; // 0 : utilisateur, 1 : technicien, 2 : responsable
            MaterielId = materielId;
        }

        public string Matricule { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string MotDePasse { get; set; }
        public int Type { get; set; } 
        public int MaterielId {get; set;} 

    }
}
