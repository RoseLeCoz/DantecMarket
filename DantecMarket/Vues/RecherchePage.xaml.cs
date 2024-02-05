using Microsoft.Maui.Storage;
using System;

namespace DantecMarket.Vues
{
    public partial class RecherchePage : ContentPage
    {
        // Variable pour stocker le critère de filtrage sélectionné
        private string selectedFilter;

        public RecherchePage()
        {
            InitializeComponent();

            // Assurez-vous que le nom de votre Picker et de votre SearchBar correspond à ceux définis dans votre XAML
            filterPicker.SelectedIndexChanged += FilterPicker_SelectedIndexChanged;
            searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;
        }

        // Gestionnaire d'événements pour le changement de sélection du Picker
        private void FilterPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterPicker.SelectedIndex == -1)
            {
                selectedFilter = null;
            }
            else
            {
                selectedFilter = (string)filterPicker.ItemsSource[filterPicker.SelectedIndex];
            }
        }

        // Gestionnaire d'événements pour la recherche
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = searchBar.Text;
            PerformSearch(searchText, selectedFilter);
        }

        // Méthode pour effectuer la recherche avec le texte et le filtre sélectionné
        private void PerformSearch(string searchText, string filter)
        {
            // Ajoutez ici votre logique de recherche
            // Par exemple, filtrer votre liste de produits en fonction du searchText et du filter
            Console.WriteLine($"Recherche de '{searchText}' avec le filtre '{filter}'");
        }
    }
}
