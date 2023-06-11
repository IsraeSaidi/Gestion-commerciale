using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_commerciale
{
    internal class Cli
    {

        public int clientId { get; set; }
        public string clientNom { get; set; }

        public Cli(int id, string nom)
        {
            clientId = id;
            clientNom = nom;
        }
    }
}
