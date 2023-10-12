using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Visiteur : Personnel
    {
        public Visiteur(string matricule, DateTime dateEmbauche, string motDePasse, int type, int materielId, int id,
            string prime, string budget, string objectif) : base(matricule, dateEmbauche, motDePasse, type, materielId)
        {
            Id = id;
            Prime = prime;
            Budget = budget;
            Objectif = objectif;
        }

        public string Objectif { get; set; }

        public string Budget { get; set; }

        public string Prime { get; set; }

        public int Id { get; set; }
    }
}
