using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetSlamTest
{
    public class Region
    {

        public Region(int id, string nom)
        {
            Id = id;
            Nom = nom;
        }

        public int Id { get; private set; }
        public string Nom { get; private set; }

    }
}
