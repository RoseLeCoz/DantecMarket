namespace DantecMarket.Vues;

using DantecMarket.Modeles;
using Microsoft.Maui.Controls;
using System;

public partial class ProduitPage : ContentPage
{
	public ProduitPage()
	{
		InitializeComponent();
        LoadProductDetails();
    }

    private void LoadProductDetails()
    {
        // Création d'un produit fictif
        Produit produit = new Produit()
        {
            Id = 1,
            Nom = "Produit1",
            Description = "Ceci est une description de produit exemple.",
            Prix = 19.99m,
            Qantite_Disponible = 15,
            DescriptionCourte = "Petit gateau "
        };

        // Liaison des données du produit aux contrôles de l'interface utilisateur
        ProduitName.Text = produit.Nom;
        ProduitDescription.Text = produit.Description;
        ProduitPrice.Text = $"{produit.Prix}€";

    }
}