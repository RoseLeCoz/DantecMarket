using System;
using System.Collections.Generic;
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
        private string _email;
        private string _motDePasse;
        private string _telephone;
        #endregion

        #region Constructeur
        #endregion

        #region Getters/Setters
        public int GetId()
        {
            return _id;
        }

        public string GetNom()
        {
            return _nom;
        }

        public string SetNom(string nom)
        {
            _nom = nom;
            return _nom;
        }

        public string GetPrenom()
        {
            return _prenom;
        }

        public string SetPrenom(string prenom)
        {
            _prenom = prenom;
            return _prenom;
        }

        public string GetEmail()
        {
            return _email;
        }

        public string SetEmail(string email)
        {
            _email = email;
            return _email;
        }
        #endregion

        #region Methodes
        #endregion
    }
}
