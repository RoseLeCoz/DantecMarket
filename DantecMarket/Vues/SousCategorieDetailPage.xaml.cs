using DantecMarket.Modeles;
using Microsoft.Maui.Controls;
using System;
using DantecMarket.Apis;

namespace DantecMarket.Vues;

public partial class SousCategorieDetailPage : ContentPage
{
    public SousCategorieDetailPage()
    {
        InitializeComponent();
        LoadSousCategories();
    }

    private async void LoadSousCategories()
    {
        var api = new GestionApi();
        var sousCategories = await api.GetAllAsync<SousCategorie>("api/mobile/getLesSCategories");
        SousCategorie.CollClasse.Clear();
        foreach (var sousCategorie in sousCategories)
        {
            SousCategorie.CollClasse.Add(sousCategorie);
        }
        CollectionViewCategories.ItemsSource = SousCategorie.CollClasse;
    }
}