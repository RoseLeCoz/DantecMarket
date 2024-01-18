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

            if (res && U1.GetNom() == "le gall" && U1.GetPrenom() == "thierry" && U1.GetPassword() == "fG45.R5y")
            {
                await Navigation.PushAsync(new AccueilPage());
            }
            else
            {
                Console.WriteLine("Problème dans le mot de passe ou le login.");
            }
        }
    }
}