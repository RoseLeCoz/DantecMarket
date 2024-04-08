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
    public class Categorie
    {
        #region Attributs
        private int _id;
        private string _nom;
        public static List<Categorie> CollClasse = new List<Categorie>();
        private readonly GestionApi _apiServices = new GestionApi();
        #endregion

        #region Constructeur
        public Categorie(int id, string nom)
        {
            Categorie.CollClasse.Add(this);
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
        public async Task<bool> GetCategories()
        {
            try
            {
                // Utilisez GetAllAsync pour récupérer toutes les catégories depuis l'API
                ObservableCollection<Categorie> resultats = await _apiServices.GetAllAsync<Categorie>("api/mobile/getLesCategories");

                if (resultats != null && resultats.Count > 0)
                {
                    // Supposons que CollClasse est la collection observable où vous voulez stocker les catégories
                    Categorie.CollClasse.Clear(); // Effacez les anciennes données
                    foreach (var categorie in resultats)
                    {
                        Categorie.CollClasse.Add(categorie); // Ajoutez chaque catégorie récupérée à la collection
                    }

                    return true; // Retournez true si les catégories ont été récupérées et stockées avec succès
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                Console.WriteLine($"Une erreur est survenue lors de la récupération des catégories : {ex.Message}");
            }

            return false; // Retournez false si la récupération a échoué
        }
        #endregion
    }
}
