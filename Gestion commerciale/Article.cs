using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_commerciale
{
    internal class Article
    {
        public int articleId { get; set; }
        public string articleLibelle { get; set; }

        public double  articlePU { get; set; }

        public Article(int id, string libelle, double pu)
        {
            articleId = id;
            articleLibelle = libelle;
            articlePU = pu; 
        }

    }
}
