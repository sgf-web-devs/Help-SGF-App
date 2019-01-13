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
        }
    }
}
