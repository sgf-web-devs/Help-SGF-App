using System;
using System.Collections.Generic;
using HelpSGF.Services;
using HelpSGF.Models;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace HelpSGF.Views
{
    public partial class LocationsPage : ContentPage
    {
        public string Tester { get; set; }
        public DataService dataService = new DataService();
        ObservableCollection<Location> Locations = new ObservableCollection<Location>();


        public LocationsPage()
        {
            Tester = "Does this work?";
            InitializeComponent();

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
    }
}
