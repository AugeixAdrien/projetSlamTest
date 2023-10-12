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

        // Constructeur sans ID
        public Ticket(string objet, int niveauUrgence, DateTime dateCreation, string etat, int idTechnicien,
            int idMateriel, string personnelMatricule)
        {
            Objet = objet;
            NiveauUrgence = niveauUrgence;
            DateCreation = dateCreation;
            Etat = etat;
            IdTechnicien = idTechnicien;
            IdMateriel = idMateriel;
            Matricule = personnelMatricule;
        }

        // Constructeur sans ID Technicien (quand le ticket vient d'être ouvert et que personne ne travaille encore dessus)
        public Ticket(string objet, int niveauUrgence, DateTime dateCreation, string etat,
            int idMateriel, string personnelMatricule)
        {
            Objet = objet;
            NiveauUrgence = niveauUrgence;
            DateCreation = dateCreation;
            Etat = etat;
            IdMateriel = idMateriel;
            Matricule = personnelMatricule;
        }

        public int IdMateriel { get; }
        
        public string Matricule { get; }

        public int IdTechnicien { get; set; }

        public string Etat { get; }

        public DateTime DateCreation { get; }

        public int NiveauUrgence { get; }

        public string Objet { get; }

        public int Id { get; }
    }
}
