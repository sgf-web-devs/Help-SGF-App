using System;
using System.Collections.Generic;
using System.Linq;
using HelpSGF.Services;
using HelpSGF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using NavigationPage = Xamarin.Forms.NavigationPage;

namespace HelpSGF.Views
{
    public partial class SearchPage : ContentPage
    {
        public DataService dataService = new DataService();
        public SearchPageViewModel viewmodel;


        void Handle_Clicked(Button sender, System.EventArgs e)
        {
            var value = sender.CommandParameter.ToString();

            var maincategory = viewmodel.Categories.First(c => c.Id == Int32.Parse(value));

            if(maincategory == null)
            {
                return;
            }

            var categories = maincategory.Categories;

            var categoriesViewModel = new CategoriesViewModel
            {
                Categories = categories,
                MainCategory = maincategory
            };

            Navigation.PushAsync(new CategoriesPage(categoriesViewModel));
        }

        public SearchPage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewmodel = new SearchPageViewModel();
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

            GetCategories();

            SearchBar.SearchCommand = new Command(async () =>
            {
                var locations = dataService.SearchLocations(SearchBar.Text);
                var locationsViewModel = new ResultsViewModel
                {
                    Locations = locations
                };

                await Navigation.PushAsync(new LocationsPage(locationsViewModel));
            });
        }

        public async void GetCategories()
        {
            var categories = await dataService.GetMainCategoriesAsync();
            var hey = categories;
            viewmodel.Categories = categories;
            ButtonLayout.IsVisible = true;
        }
    }
}
