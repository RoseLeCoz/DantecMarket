﻿using DantecMarket.Apis;
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
        private int _id;
        private string _nom;
        private string _prenom;
        private string _password;
        public static List<User> CollClasse = new List<User>();
        private readonly GestionApi _apiServices = new GestionApi();
        #endregion

        #region Constructeur
        public User(int id, string nom, string prenom, string password)
        {
            User.CollClasse.Add(this);
            this._id = id;
            this._nom = nom;
            this._prenom = prenom;
            this._password = password;
        }
        #endregion

        #region Getters/Setters
        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Nom
        {
            get => _nom;
            set => _nom = value;
        }

        public string Prenom
        {
            get => _prenom;
            set => _prenom = value;
        }

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
                // Assurez-vous que _apiServices est initialisé
                if (_apiServices == null)
                {
                    throw new InvalidOperationException("_apiServices not initialized");
                }

                User resultat = await _apiServices.GetOneAsync<User>("api/mobile/GetFindUser", this);

                if (resultat != null)
                {
                    Constantes.CurrentUser = resultat;

                    // Vérifiez si c'est vraiment ce que vous voulez faire.
                    // Si la collection ne doit contenir que l'utilisateur actuel, c'est correct.
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
