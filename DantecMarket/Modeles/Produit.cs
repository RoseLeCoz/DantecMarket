using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DantecMarket.Modeles
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public decimal Prix { get; set; }
        public int Qantite_Disponible { get; set; }
        public string DescriptionCourte { get; set; }
        public decimal Etoiles { get; set; }
    }
}
