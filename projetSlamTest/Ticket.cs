using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    internal class Ticket
    {
    }
}
﻿namespace projetSlamTest

namespace projetSlamTest
{
    public class Ticket
    {
        // un ticket a :
        // un id : int
        // un objet : string
        // un niveau d'urgence : int
        // une date de creation : DateTime
        // un etat : string
        // un idTechnicien : int
        // un idMateriel : int
        
        // fais le contructeur de la classe
        
        public Ticket (int id, string objet, int niveauUrgence, DateTime dateCreation, string etat, int idTechnicien, int idMateriel)
        {
            Id = id;
            Objet = objet;
            NiveauUrgence = niveauUrgence;
            DateCreation = dateCreation;
            Etat = etat;
            IdTechnicien = idTechnicien;
            IdMateriel = idMateriel;
        }

        public int IdMateriel { get; set; }

        public int IdTechnicien { get; set; }

        public string Etat { get; set; }

        public DateTime DateCreation { get; set; }

        public int NiveauUrgence { get; set; }

        public string Objet { get; set; }

        public int Id { get; set; }
    }
}
