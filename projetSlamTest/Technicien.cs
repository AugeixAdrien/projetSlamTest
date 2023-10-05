using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Technicien
    {


        public Technicien(int id, string niveau, string formation, string competences, string matricule)
        {
            Id = id;
            Niveau = niveau;
            Formation = formation;
            Competences = competences;
            Matricule = matricule;
        }

        public int Id { get; set; }

        public string Niveau { get; set; }

        public string Formation { get; set; }

        public string Competences { get; set; }

        public string Matricule { get; set; }

    }
}