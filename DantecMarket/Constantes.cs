using DantecMarket.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DantecMarket
{
    public class Constantes
    {
        public static string BaseApiAddress => "http://172.17.0.64/";
        public static User CurrentUser = null;
        public static Produit CurrentProduit = null;
        public static Categorie CurrentCategorie = null;
        public static SousCategorie CurrentSousCategorie = null;
    }
}
