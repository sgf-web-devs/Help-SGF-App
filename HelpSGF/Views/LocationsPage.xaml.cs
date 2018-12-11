using System;
using System.Collections.Generic;
using HelpSGF.Services;
using HelpSGF.Models;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using HelpSGF.ViewModels;

namespace HelpSGF.Views
{
    public partial class LocationsPage : ContentPage
    {
        public string Tester { get; set; }
        public DataService dataService = new DataService();
        ObservableCollection<Location> Locations = new ObservableCollection<Location>();


        public LocationsPage()
        {
            BindingContext = new SelectionFilter();
            Tester = "Does this work?";
            InitializeComponent();
            Title = "Results";

            Locations = dataService.GetLocations();
            LocationsListView.ItemsSource = Locations;
        }

        public void OnLocationSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Location location))
                return;

            Console.WriteLine(location.Name + " Tapped");
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            LocationsListView.SelectedItem = null;
        }

        public void OnFilterTap(object sender, EventArgs args)
        {
            var view = sender as View;
            var filter = view?.BindingContext as string;
            DisplayAlert("Filter Function Coming...", "You have selected " + filter, "Ok");
        }
    }
}
