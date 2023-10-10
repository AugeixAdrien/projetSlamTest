using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Ticket
    {
        public Ticket (int id, string objet, int niveauUrgence, DateTime dateCreation, string etat, int idTechnicien, 
            int idMateriel, string personnelMatricule)
        {
            Id = id;
            Objet = objet;
            NiveauUrgence = niveauUrgence;
            DateCreation = dateCreation;
            Etat = etat;
            IdTechnicien = idTechnicien;
            IdMateriel = idMateriel;
            Matricule = personnelMatricule;
        }

        public int IdMateriel { get; set; }
        
        public string Matricule { get; set; }

        public int IdTechnicien { get; set; }

        public string Etat { get; set; }

        public DateTime DateCreation { get; set; }

        public int NiveauUrgence { get; set; }

        public string Objet { get; set; }

        public int Id { get; set; }

        public int PersonnelMatricule { get; set; }
    }
}
