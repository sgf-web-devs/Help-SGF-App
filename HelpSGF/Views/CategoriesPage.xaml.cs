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

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            if(((ListView)sender).SelectedItem != null)
            {
                try
                {
                    var category = (KeyValuePair<string, int>)args.SelectedItem;
                    var locations = dataService.FilterLocations(viewModel.MainCategoryName + " > " + category.Key);

                    var resultsViewModel = new ResultsViewModel
                    {
                        LocationSearchResultItems = locations
                    };

                    ((ListView)sender).SelectedItem = null;

                    Navigation.PushAsync(new LocationsPage(resultsViewModel));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Nothing selected here");
            }
        }
    }

}
