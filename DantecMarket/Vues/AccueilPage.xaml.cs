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

            imageCarousel.PositionChanged += CarouselView_PositionChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Red�marre le timer lors du retour sur la page
            _carouselTimer?.Change(0, 6000);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // Arr�te le timer lorsqu'on quitte la page pour �viter des appels inutiles
            _carouselTimer?.Change(Timeout.Infinite, Timeout.Infinite);
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

        private void CarouselView_PositionChanged(object sender, PositionChangedEventArgs e)
        {
            _currentIndex = e.CurrentPosition;
        }

        private async void OnCategorieClicked(object sender, EventArgs e)
        {
            var bouton = sender as ImageButton;
            if (bouton != null)
            {
                var categorieName = bouton.CommandParameter.ToString();
                var lesCategories = new CategoriePage(); // Assurez-vous que votre ProductPage peut accepter une string dans son constructeur

                await Navigation.PushAsync(lesCategories);
            }
        }
    }
}
