using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Technicien : Personnel
    {
        public Technicien(string matricule, DateTime dateEmbauche, string motDePasse, int type, int materielId, int id, string niveau, string formation, string competences) : base(matricule, dateEmbauche, motDePasse, type, materielId)
        {

            Id = id;
            Niveau = niveau;
            Formation = formation;
            Competences = competences;

        }

        public int Id { get; set; }

        public string Niveau { get; set; }
        public string Formation { get; set; }
        public string Competences { get; set; }
    }
}
