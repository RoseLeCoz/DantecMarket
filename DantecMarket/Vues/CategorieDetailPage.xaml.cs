using DantecMarket.Modeles;
using Microsoft.Maui.Controls;
using System;
using DantecMarket.Apis;
using Newtonsoft.Json;

namespace DantecMarket.Vues;

public partial class CategorieDetailPage : ContentPage
{
    private HttpClient _httpClient = new HttpClient();
    private readonly GestionApi _apiServices = new GestionApi();

    public CategorieDetailPage(int categoryId)
    {
        InitializeComponent();
        LoadChildCategories(categoryId);
    }

    private async void LoadChildCategories(int categoryId)
    {
        var api = new GestionApi();
        var categories = await api.GetAllAsync<Categorie>($"api/categories/{categoryId}");
        Categorie.CollClasse.Clear(); // Effacez les anciennes données
        foreach (var categorie in categories)
        {
            Categorie.CollClasse.Add(categorie);
        }
        categoriesListView.ItemsPanel = Categorie.CollClasse;
    }
}