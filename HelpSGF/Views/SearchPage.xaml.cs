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


        void Handle_Clicked(object sender, System.EventArgs e)
        {

            var imageButton = (ImageButton)sender;

            var value = imageButton.CommandParameter.ToString();

            var maincategory = viewmodel.Categories.First(c => c.Id == Int32.Parse(value));

            if(maincategory == null)
            {
                return;
            }

            var categories = maincategory.SubCategories;

            var categoriesViewModel = new CategoriesViewModel
            {
                Categories = viewmodel.SearchFacets["categories.lvl1"].Where(p => p.Key.Contains(maincategory.Name + " > ")).ToDictionary(dict => dict.Key.Replace(maincategory.Name + " > ", ""), dict => dict.Value),
                MainCategoryName = maincategory.Name
            };


            Navigation.PushAsync(new CategoriesPage(categoriesViewModel));
        }

        public SearchPage()
        {
            NavigationPage.SetBackButtonTitle(this, "");
            BindingContext = viewmodel = new SearchPageViewModel();
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);



            SearchBar.SearchCommand = new Command(async () =>
            {
                var locations = dataService.SearchLocations(SearchBar.Text);
                var locationsViewModel = new ResultsViewModel
                {
                    LocationSearchResultItems = locations
                };

                await Navigation.PushAsync(new LocationsPage(locationsViewModel));
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // This might be a bit much, but for now this will ensure that
            // the main screen icons are always up to date.
            GetCategories();
        }

        public async void GetCategories()
        {

            Console.WriteLine("On appearing");
            viewmodel.Categories = await dataService.GetMainCategoriesAsync();
            viewmodel.SearchFacets = dataService.GetFacets();

            viewmodel.Categories = viewmodel.Categories.Where(p => viewmodel.SearchFacets["categories.lvl0"].Keys.Contains(p.Name)).ToList();

            ButtonLayout.IsVisible = true;

            if(viewmodel.Categories != null && viewmodel.Categories.Count > 0)
            {
                int row = 0;
                for(int i = 0; i < viewmodel.Categories.Count; i++)
                {

                    var mod3 = i % 3;

                    var category = viewmodel.Categories[i];
                    category.Row = row;
                    category.Column = mod3;

                    //Aspect = "AspectFit" BackgroundColor = "White" Source = "categories_shelter.png" Grid.Row = "0" Grid.Column = "0" CommandParameter = "2065" Clicked = "Handle_Clicked"
                    var button = new ImageButton();
                    button.Aspect = Aspect.AspectFit;
                    button.BackgroundColor = Color.White;
                    button.Source = category.RemoteImagePath;
                    button.CommandParameter = category.Id.ToString();
                    button.Clicked += Handle_Clicked;


                    CategoriesGrid.Children.Add(button, mod3, row);

                    if (mod3 == 2) row++;
                }


            }

        }


    }
}
