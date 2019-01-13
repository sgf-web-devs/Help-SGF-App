using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpSGF.Models;
using HelpSGF.Services;
using HelpSGF.ViewModels;
using Naxam.Controls.Mapbox.Forms;
using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class LocationDetailPage : ContentPage
    {
        //Location Location;
        public DataService dataService = new DataService();
        public LocationDetailViewModel viewModel;
        //private int serviceGridColumnCount = 0;
        //private int serviceGridRowCount = 0;
        private int serviceItemCount = 0;

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var annotation = (sender as View).BindingContext as Annotation;

            DisplayAlert(annotation?.Title, annotation.SubTitle, "OK");
        }

        public LocationDetailPage(string url = "")
        {
            Title = "Location";

            BindingContext = viewModel = new LocationDetailViewModel();

            InitializeComponent();

            if(!string.IsNullOrEmpty(url))
            {
                //Task.Run(async () =>
                //{
                //    await LoadLocationAsync(url);
                //});

                //MapWebView.Source = viewModel.MapURL;

                LoadLocationAsync(url);
            }

            //MapWebView.Source = "https://api.mapbox.com/styles/v1/mapbox/streets-v10.html?title=false&zoomwheel=false&access_token=pk.eyJ1IjoiaGVscHNnZiIsImEiOiJjamt4ajMwZzAwOTdqM3VwZzI2MmxlMXV3In0.iukoLZaCrGXrOvJ8VlNDaA#16/37.146/-93.2738";
        }

        public async void LoadLocationAsync(string url)
        {
            var location = await dataService.GetLocationAsync(url);
            viewModel.Location = location;

            // Embedded Map View
            MapWebView.Source = viewModel.MapURL;

            // Service List Grid
            try
            {
                if (viewModel.Location.ServiceTypes != null)
                {
                    foreach (string service in viewModel.Location.ServiceTypes)
                    {
                        var column = serviceItemCount % 2 == 0 ? 0 : 1;

                        var label = new Label();
                        label.Text = "•  " + service;
                        ServiceGrid.Children.Add(label, column, (int)Math.Floor((double)serviceItemCount / 2));

                        serviceItemCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Address
            AddressLabel.Text = viewModel.Location.FormattedAddress;

            // Contact List
            foreach (var contact in viewModel.Location.contacts)
            {
                var contactType = contact.ContactType;
                var imageIcon = "call.png";
                if(contactType == "email") { imageIcon = "email.png"; }

                var contentStackLayout = new StackLayout { Padding = new Thickness { Left = 20, Top = 20 } };
                var lineStackLayout = new StackLayout { Padding = new Thickness { Left = 20, Right = 20 }, Margin = new Thickness { Top = 10 } };
                var boxView = new BoxView
                {
                    BackgroundColor = Color.FromHex("DADADA"),
                    HeightRequest = 2,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Margin = 0
                };

                lineStackLayout.Children.Add(boxView);

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 30 });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                var image = new Image { Source = imageIcon };
                var textStackLayout = new StackLayout { Margin = new Thickness { Left = 10 } };
                var title = new Label { FontSize = 16, FontAttributes = FontAttributes.Bold, Text = contact.ContactType };
                var description = new Label { FontSize = 17, TextColor = Color.FromHex("813C27"), Text = contact.ContactData };

                textStackLayout.Children.Add(title);
                textStackLayout.Children.Add(description);

                grid.Children.Add(image, 0, 0);
                grid.Children.Add(textStackLayout, 1, 0);

                contentStackLayout.Children.Add(grid);

                ContactList.Children.Add(contentStackLayout);
                ContactList.Children.Add(lineStackLayout);
            }
        }
    }
}
