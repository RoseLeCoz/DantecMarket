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
    public class SousCategorie
    {
        #region Attributs
        private int _id;
        private string _nom;
        public static List<SousCategorie> CollClasse = new List<SousCategorie>();
        private readonly GestionApi _apiServices = new GestionApi();
        #endregion

        #region Constructeur
        public SousCategorie(int id, string nom)
        {
            SousCategorie.CollClasse.Add(this);
            this._id = id;
            this._nom = nom;
        }
        #endregion

        #region Getters/Setters
        [JsonProperty("Id")]
        public int Id
        { get => _id; set => _id = value; }

        [JsonProperty("Nom")]
        public string Nom
        { get => _nom; set => _nom = value; }
        #endregion

        #region Methodes
        public async Task<bool> GetSousCategories()
        {
            try
            {
                // Utilisez GetAllAsync pour récupérer toutes les catégories depuis l'API
                ObservableCollection<SousCategorie> resultats = await _apiServices.GetAllAsync<SousCategorie>("api/mobile/getLesCategories");

                if (resultats != null && resultats.Count > 0)
                {
                    // Supposons que CollClasse est la collection observable où vous voulez stocker les catégories
                    SousCategorie.CollClasse.Clear(); // Effacez les anciennes données
                    foreach (var sousCategorie in resultats)
                    {
                        SousCategorie.CollClasse.Add(sousCategorie); // Ajoutez chaque catégorie récupérée à la collection
                    }

                    return true; // Retournez true si les catégories ont été récupérées et stockées avec succès
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                Console.WriteLine($"Une erreur est survenue lors de la récupération des sous catégories : {ex.Message}");
            }

            return false; // Retournez false si la récupération a échoué
        }
        #endregion
    }
}
