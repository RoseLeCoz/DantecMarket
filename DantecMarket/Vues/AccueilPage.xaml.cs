using DantecMarket.Apis;
using DantecMarket.Modeles;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;
using System;
using System.Collections.ObjectModel;
using System.Timers;
using Timer = System.Timers.Timer;

namespace DantecMarket.Vues
{
    public partial class AccueilPage : ContentPage
    {
        private readonly GestionApi _apiServices = new GestionApi();
        private int currentPosition = 0;
        private Timer timerCarousel;
        private List<string> imagesProduits; // Déclarée au niveau de la classe

        public AccueilPage()
        {
            InitializeComponent();

            // Initialiser la variable membre de la classe, et non une variable locale
            imagesProduits = new List<string>
        {
            "logo.jpg",
            "categorie3.jpg",
            "dotnet_bot.png"
        };

            carouselViewProduits.ItemsSource = imagesProduits;

            // Configuration et démarrage du timer
            timerCarousel = new Timer
            {
                Interval = 6000, // Change l'image toutes les 6 secondes
                AutoReset = true,
                Enabled = true
            };
            timerCarousel.Elapsed += OnTimedEvent;
            timerCarousel.Start();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                currentPosition = (currentPosition + 1) % imagesProduits.Count;
                carouselViewProduits.Position = currentPosition;
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (timerCarousel == null)
            {
                timerCarousel = new Timer
                {
                    Interval = 6000, // Change l'image toutes les 6 secondes
                    AutoReset = true
                };
                timerCarousel.Elapsed += OnTimedEvent;
            }

            timerCarousel.Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (timerCarousel != null)
            {
                timerCarousel.Stop();
                timerCarousel.Elapsed -= OnTimedEvent; // Important pour éviter les fuites de mémoire
                timerCarousel.Dispose();
                timerCarousel = null;
            }
        }
    }
}