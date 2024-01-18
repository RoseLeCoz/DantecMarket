using DantecMarket.Apis;
using DantecMarket.Modeles;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Maui.Controls;
using System;

namespace DantecMarket.Vues
{
    public partial class AccueilPage : ContentPage
    {
        private readonly GestionApi _apiServices = new GestionApi();

        public AccueilPage()
        {
            InitializeComponent();
        }
    }
}