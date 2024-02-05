using Microsoft.Maui.Storage;
using System;

namespace DantecMarket.Vues
{
    public partial class RecherchePage : ContentPage
    {
        // Variable pour stocker le crit�re de filtrage s�lectionn�
        private string selectedFilter;

        public RecherchePage()
        {
            InitializeComponent();

            // Assurez-vous que le nom de votre Picker et de votre SearchBar correspond � ceux d�finis dans votre XAML
            filterPicker.SelectedIndexChanged += FilterPicker_SelectedIndexChanged;
            searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;
        }

        // Gestionnaire d'�v�nements pour le changement de s�lection du Picker
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

        // Gestionnaire d'�v�nements pour la recherche
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = searchBar.Text;
            PerformSearch(searchText, selectedFilter);
        }

        // M�thode pour effectuer la recherche avec le texte et le filtre s�lectionn�
        private void PerformSearch(string searchText, string filter)
        {
            // Ajoutez ici votre logique de recherche
            // Par exemple, filtrer votre liste de produits en fonction du searchText et du filter
            Console.WriteLine($"Recherche de '{searchText}' avec le filtre '{filter}'");
        }
    }
}
