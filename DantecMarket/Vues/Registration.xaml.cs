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
            var nom = NomEntry.Text;
            var prenom = PrenomEntry.Text;
            var password = PasswordEntry.Text;

            User U1 = new User(1, nom, prenom, password);
            bool registrationSuccessful = await U1.GetUserRegistration();

            if (registrationSuccessful)
            {
                await Navigation.PushAsync(new AccueilPage());
            }
            else
            {
                // Afficher une boîte de dialogue avec un message d'erreur
                await DisplayAlert("Erreur", "La connexion a échoué. Veuillez vérifier vos informations.", "OK");
            }
        }
    }
}