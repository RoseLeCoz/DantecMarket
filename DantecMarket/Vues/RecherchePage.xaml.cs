using Microsoft.Maui.Storage;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DantecMarket.Vues
{
    public partial class RecherchePage : ContentPage
    {
        public ObservableCollection<string> SelectedFilters { get; set; }
        public ICommand RemoveFilterCommand { get; private set; } // Commande pour supprimer un filtre

        public RecherchePage()
        {
            InitializeComponent();

            SelectedFilters = new ObservableCollection<string>();
            selectedFiltersView.ItemsSource = SelectedFilters;

            RemoveFilterCommand = new Command<string>(RemoveFilter); // Initialiser la commande

            filterPicker.SelectedIndexChanged += OnFilterSelected;
            searchBar.SearchButtonPressed += SearchBar_SearchButtonPressed;
        }

        // Gestionnaire d'�v�nements pour le changement de s�lection du Picker
        private void OnFilterSelected(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            if (picker == null || picker.SelectedIndex == -1) return;

            var selectedFilter = picker.SelectedItem as string;
            if (!SelectedFilters.Contains(selectedFilter))
            {
                SelectedFilters.Add(selectedFilter);
            }

            // R�initialiser la s�lection du Picker
            picker.SelectedIndex = -1;
        }

        // Gestionnaire d'�v�nements pour la recherche
        private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            var searchText = searchBar.Text ?? string.Empty;
            PerformSearch(searchText);
        }

        // M�thode pour effectuer la recherche avec le texte et les filtres s�lectionn�s
        private void PerformSearch(string searchText)
        {
            // Logique de recherche
            Console.WriteLine($"Recherche de '{searchText}' avec les filtres '{string.Join(", ", SelectedFilters)}'");
        }

        // M�thode pour supprimer un filtre de la liste
        private void RemoveFilter(string filter)
        {
            SelectedFilters.Remove(filter);
        }

        public void RemoveFilterButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var filter = button.CommandParameter as string;
                if (SelectedFilters.Contains(filter))
                {
                    SelectedFilters.Remove(filter);
                }
            }
        }
    }
}
