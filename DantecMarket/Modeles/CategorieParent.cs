using DantecMarket.Apis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DantecMarket.Modeles
{
    public class CategorieParent
    {
        #region Attributs
        private int _id;
        private string _nom;
        public static List<CategorieParent> CollClasse = new List<CategorieParent>();
        private readonly GestionApi _apiServices = new GestionApi();
        #endregion

        #region Constructeur
        public CategorieParent(int id, string nom)
        {
            CategorieParent.CollClasse.Add(this);
            this._id = id;
            this._nom = nom;
        }
        #endregion

        #region Getters/Setters
        [JsonProperty("Id")]
        public int Id
        { get => _id; set => _id = value;}

        [JsonProperty("Nom")]
        public string Nom
        { get => _nom; set => _nom = value;}
        #endregion

        #region Methodes
        #endregion
    }
}
