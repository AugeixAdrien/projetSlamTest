using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace projetSlamTest
{
    public class Materiel
    {
        public Materiel (int id, string processeur, string memoire, string disque, List<string> logiciels, DateTime dateAchat, string garantie, string fournisseur)
        {
            Id = id;
            Processeur = processeur;
            Memoire = memoire;
            Disque = disque;
            Logiciels = logiciels;
            DateAchat = dateAchat;
            Garantie = garantie;
            Fournisseur = fournisseur;
        }

        // Ajout de matériel sans ID
        public Materiel( string processeur, string memoire, string disque, List<string> logiciels, DateTime dateAchat, string garantie, string fournisseur)
        {
            Processeur = processeur;
            Memoire = memoire;
            Disque = disque;
            Logiciels = logiciels;
            DateAchat = dateAchat;
            Garantie = garantie;
            Fournisseur = fournisseur;
        }

        public int Id { get; set; }

        public string Fournisseur { get; set; }

        public string Garantie { get; set; }

        public DateTime DateAchat { get; set; }

        public List<string> Logiciels { get; }

        public string Disque { get; set; }

        public string Memoire { get; set; }

        public string Processeur { get; set; }
    }
}
