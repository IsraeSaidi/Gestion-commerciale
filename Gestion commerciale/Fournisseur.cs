using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_commerciale
{
    internal class Fournisseur { 
    
            public int fournisseurId { get; set; }
            public string fournisseurNom { get; set; }

            public Fournisseur(int id, string nom)
            {
                fournisseurId = id;
                fournisseurNom = nom;
            }
        
    }
}
