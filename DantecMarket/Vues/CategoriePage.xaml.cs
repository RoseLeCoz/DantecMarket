using DantecMarket.Modeles;
using Microsoft.Maui.Controls;
using System;
using DantecMarket.Apis;

namespace DantecMarket.Vues;

public partial class CategoriePage : ContentPage
{
    public CategoriePage()
	{
		InitializeComponent();
        LoadCategories();
    }

    private async void LoadCategories()
    {
        var api = new GestionApi();
        var categories = await api.GetAllAsync<Categorie>("api/mobile/getLesCategories");
        foreach (var categorie in categories)
        {
            Categorie.CollClasse.Add(categorie);
        }
        CollectionViewCategories.ItemsSource = Categorie.CollClasse;
    }

}