using System;
using System.Collections.Generic;
using HelpSGF.Models;
using HelpSGF.Views;
using HelpSGF.ViewModels;
using System.Linq;
using Xamarin.Forms;
using HelpSGF.Services;

namespace HelpSGF.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;
        public DataService dataService = new DataService();

        public CategoriesPage(CategoriesViewModel vm)
        {
            InitializeComponent();

            Title = vm.MainCategoryName;

            NavigationPage.SetBackButtonTitle(this, "");

            BindingContext = viewModel = vm;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var category = (KeyValuePair<string, int>)e.SelectedItem;
            var locations = dataService.FilterLocations(viewModel.MainCategoryName + " > " + category.Key);

            var resultsViewModel = new ResultsViewModel
            {
                LocationSearchResultItems = locations
            };

            Navigation.PushAsync(new LocationsPage(resultsViewModel));
        }
    }

}
