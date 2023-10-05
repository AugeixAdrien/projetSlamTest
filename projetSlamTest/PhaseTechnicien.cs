using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class PhaseTechnicien
    {

        public PhaseTechnicien(string id, DateTime dateDebut, DateTime dateFin, string travailRealise)
        {
            Id = id;
            DateDebut = dateDebut;
            DateFin = dateFin;
            TravailRealise = travailRealise;
        }

        public string Id { get; set; }

        public DateTime DateDebut { get; set; }

        public DateTime DateFin { get; set; }

        public string TravailRealise { get; set; }
    }
}

