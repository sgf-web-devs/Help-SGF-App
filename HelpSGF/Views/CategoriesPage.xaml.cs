using System;
using System.Collections.Generic;
using HelpSGF.Models;
using HelpSGF.Views;
using HelpSGF.ViewModels;

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

            Title = vm.MainCategory.Name;

            NavigationPage.SetBackButtonTitle(this, "");

            BindingContext = viewModel = vm;
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var category = (Category)e.SelectedItem;
            var locations = dataService.FilterLocations(category.ServiceType);

            var resultsViewModel = new ResultsViewModel
            {
                Locations = locations
            };

            Navigation.PushAsync(new LocationsPage(resultsViewModel));
        }
    }

}
