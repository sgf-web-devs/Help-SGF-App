using System;
using System.Collections.Generic;
using HelpSGF.Models;
using HelpSGF.ViewModels;
using Naxam.Controls.Mapbox.Forms;
using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class LocationDetailPage : ContentPage
    {
        //Location Location;

        void Handle_Tapped(object sender, System.EventArgs e)
        {
            var annotation = (sender as View).BindingContext as Annotation;

            DisplayAlert(annotation?.Title, annotation.SubTitle, "OK");
        }

        public LocationDetailPage()
        {
            Title = "Location";

            InitializeComponent();

            MapWebView.Source = "https://api.mapbox.com/styles/v1/mapbox/streets-v10.html?title=false&zoomwheel=false&access_token=pk.eyJ1IjoiaGVscHNnZiIsImEiOiJjamt4ajMwZzAwOTdqM3VwZzI2MmxlMXV3In0.iukoLZaCrGXrOvJ8VlNDaA#16/37.146/-93.2738";
        }
    }
}
