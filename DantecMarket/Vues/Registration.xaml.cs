using DantecMarket.Apis;
using DantecMarket.Modeles;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls;
using System;

namespace DantecMarket.Vues
{
    public partial class Registration : ContentPage
    {
        private readonly GestionApi _apiServices = new GestionApi();

        public Registration()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var nom = NameEntry.Text;
            var prenom = PrenomEntry.Text;
            var password = PasswordEntry.Text;

            User U1 = new User(1, nom, prenom, password);
            bool res = await U1.GetUserRegistration();

            if (res)
            {
                // La requ�te API est la m�me dans les deux cas, donc on la d�place hors du if
                // var result = await _apiServices.GetAllAsyncByID<User>("api/mobile/GetAllUsers", "Id", U1.Id);

                if (U1.GetNom() == "le gall" && U1.GetPrenom() == "thierry" && U1.GetPassword() == "fG45.R5y")
                {
                    await Navigation.PushAsync(new AccueilPage());
                }
                else
                {
                    // Redirection vers la page Accueil
                    await Navigation.PushAsync(new AccueilPage());
                }
            }
            else
            {
                // G�rer le cas o� GetUserRegistration retourne false (si n�cessaire)
                // Exemple : Afficher un message d'erreur
            }
        }

        private async void UserButton_Clicked(object sender, EventArgs e)
        {
            var nom = NameEntry.Text;
            var prenom = PrenomEntry.Text;
            var password = PasswordEntry.Text;

            User U1 = new User(1, nom, prenom, password);
            bool res = await U1.GetUserRegistration();

            if (res)
            {
                // La requ�te API est la m�me dans les deux cas, donc on la d�place hors du if
                // var result = await _apiServices.GetAllAsyncByID<User>("api/mobile/GetAllUsers", "Id", U1.Id);


                // Redirection vers la page Accueil
                //await Navigation.PushAsync(new UserPage());

            }
            else
            {
                // G�rer le cas o� GetUserRegistration retourne false (si n�cessaire)
                // Exemple : Afficher un message d'erreur
            }
        }
    }
}