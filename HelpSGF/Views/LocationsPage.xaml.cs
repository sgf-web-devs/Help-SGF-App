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

        ResultsViewModel viewModel;


        public LocationsPage(ResultsViewModel viewModel)
        {
            //BindingContext = new ResultsViewModel();
            Tester = "Does this work?";
            InitializeComponent();
            Title = "Results";

            BindingContext = this.viewModel = viewModel;

            //Locations = dataService.GetLocations();
            //LocationsListView.ItemsSource = Locations;
        }

        void OnLocationSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if (!(args.SelectedItem is Location location))
                return;

            Console.WriteLine(location.Name + " Tapped");
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
            //await Navigation.PushAsync(new LocationDetailPage(new LocationDetailPage(item)));
            Navigation.PushAsync(new LocationDetailPage());

            // Manually deselect item.
            LocationsListView.SelectedItem = null;
        }

        public void OnFilterTap(object sender, EventArgs args)
        {
            var categoryFilterPage = new NavigationPage(new CategoryFilterPage())
            {
                BarBackgroundColor = Color.FromHex("#B4E2D9"),
                BarTextColor = Color.Black
            };

            Navigation.PushModalAsync(categoryFilterPage);
        }

        public void OnFilterItemTap(object sender, EventArgs args)
        {
            var view = sender as View;
            var filter = view?.BindingContext as string;
            DisplayAlert("This will work in the next release", "You have selected " + filter, "Ok");
        }
    }
}
