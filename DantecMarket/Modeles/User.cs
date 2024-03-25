﻿using DantecMarket.Apis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DantecMarket.Modeles
{
    public class User
    {
        #region Attributs
        private string _nom;
        private string _prenom;
        private string _password;
        public static List<User> CollClasse = new List<User>();
        private readonly GestionApi _apiServices = new GestionApi();
        #endregion

        #region Constructeur
        public User(string nom, string prenom, string password)
        {
            User.CollClasse.Add(this);
            this._nom = nom;
            this._prenom = prenom;
            this._password = password;
        }
        #endregion

        #region Getters/Setters
        [JsonProperty("Nom")]
        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        [JsonProperty("Prenom")]
        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

        [JsonProperty("Password")]
        public string Password
        {
            get => _password;
            set => _password = value;
        }
        #endregion

        #region Methodes
        public async Task<bool> GetUserRegistration()
        {
            try
            {
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                User resultat = await _apiServices.GetOneAsync<User>("api/mobile/GetFindUser", this);

                if (resultat != null)
                {
                    Constantes.CurrentUser = resultat;
                    User.CollClasse.Clear();

                    return true;
                }
            }
            catch (HttpRequestException httpEx)
            {
                // Gestion spécifique des exceptions liées aux requêtes HTTP
                Console.WriteLine($"HTTP Error: {httpEx.Message}");
            }
            catch (Exception ex)
            {
                // Gestion générale des erreurs
                Console.WriteLine($"An error occurred while getting user registration: {ex.Message}");
            }

            return false;
        }
        #endregion
    }
}
