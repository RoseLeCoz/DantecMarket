using DantecMarket.Apis;
using DantecMarket.Modeles;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using Timer = System.Threading.Timer;

namespace DantecMarket.Vues
{
    public partial class AccueilPage : ContentPage
    {
        private readonly GestionApi _apiServices = new GestionApi();
        private int _currentIndex = 0;
        private List<string> Images = new List<string>();
        private Timer _carouselTimer;

        public AccueilPage()
        {
            InitializeComponent();

            // Exemple d'ajout d'images
            Images.Add("categorie3.jpg");
            Images.Add("logo.jpg");
            Images.Add("epicerie_sucree.jpg");

            imageCarousel.ItemsSource = Images;

            // Initialiser et d�marrer le Timer
            _carouselTimer = new Timer(ChangeImage, null, 6000, 6000);
        }

        private void ChangeImage(object state)
        {
            // Changer l'image sur le thread UI
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _currentIndex++;
                if (_currentIndex >= Images.Count)
                    _currentIndex = 0;

                imageCarousel.Position = _currentIndex;
            });
        }

        private async void OnCategorieClicked(object sender, EventArgs e)
        {
            var bouton = sender as ImageButton;
            if (bouton != null)
            {
                var categorieName = bouton.CommandParameter.ToString();

                // Vous pouvez passer le nom de la cat�gorie � la page de produits via son constructeur
                // ou utiliser une m�thode pour d�finir les produits apr�s la navigation
                var lesProduitsPage = new ProduitPage(); // Assurez-vous que votre ProductPage peut accepter une string dans son constructeur

                await Navigation.PushAsync(lesProduitsPage);
            }
        }

    }
}