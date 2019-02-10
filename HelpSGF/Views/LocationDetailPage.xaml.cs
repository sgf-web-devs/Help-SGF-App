using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpSGF.Models;
using HelpSGF.Services;
using HelpSGF.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

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
        private int categoryItemCount = 0;

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


            if(!viewModel.Location.Latitude.Equals(0) && !viewModel.Location.Longitude.Equals(0))
            {
                // Embedded Map View
                //MapWebView.Source = viewModel.MapURL;
                try
                {
                    var map = new Map(MapSpan.FromCenterAndRadius(new Position(viewModel.Location.Latitude, viewModel.Location.Longitude), Distance.FromMiles(0.3)))
                    {
                        //IsShowingUser = true,
                        HeightRequest = 100,
                        WidthRequest = 960,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        MapType = MapType.Street
                    };

                    MapView.Children.Add(map);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

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

                if (viewModel.Location.Categories != null && viewModel.Location.Categories.Count > 0)
                {
                    foreach (var category in viewModel.Location.Categories)
                    {
                        var column = categoryItemCount % 2 == 0 ? 0 : 1;

                        var label = new Label();
                        label.Text = "•  " + category.ServiceType;
                        CategoriesGrid.Children.Add(label, column, (int)Math.Floor((double)categoryItemCount / 2));

                        categoryItemCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // Address
            AddressLabel.Text = viewModel.Location.FormattedAddress;

            if(viewModel.Location.contacts != null)
            {
                try
                {
                    // Contact List
                    foreach (var contact in viewModel.Location.contacts)
                    {
                        var description = new Label { FontSize = 17, TextColor = Color.FromHex("813C27"), Text = contact.ContactData };
                        var contactType = contact.ContactType;
                        var imageIcon = "call.png";

                        if (contactType == "Twitter")
                        {
                            imageIcon = "twitter.png";

                            var linkUrl = contact.ContactData;

                            if (!linkUrl.StartsWith("http", StringComparison.Ordinal))
                            {
                                var username = contact.ContactData.Replace("@", "");
                                linkUrl = "https://twitter.com/" + username;
                            }

                            description.GestureRecognizers.Add(new TapGestureRecognizer
                            {
                                Command = new Command(() => {
                                    try
                                    {
                                        Device.OpenUri(new Uri(linkUrl));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                })
                            });
                        }


                        if (contactType == "Email") {
                            imageIcon = "email.png";

                            description.GestureRecognizers.Add(new TapGestureRecognizer
                            {
                                Command = new Command(() => {
                                    try
                                    {
                                        Device.OpenUri(new Uri("mailto:" + contact.ContactData));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                })
                            });
                        }


                        if (contactType == "Web Page") { 
                            imageIcon = "link.png";

                            var linkUrl = contact.ContactData;

                            if(!linkUrl.StartsWith("http", StringComparison.Ordinal))
                            {
                                linkUrl = "http://" + contact.ContactData;
                            }

                            description.GestureRecognizers.Add(new TapGestureRecognizer
                            {
                                Command = new Command(() => {
                                    try
                                    {
                                        Device.OpenUri(new Uri(linkUrl));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                })
                            });
                        }

                        if (contactType == "Phone")
                        {
                            imageIcon = "call.png";

                            description.GestureRecognizers.Add(new TapGestureRecognizer
                            {
                                Command = new Command(() => {
                                    try
                                    {
                                        Device.OpenUri(new Uri("tel:" + contact.ContactData));
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                })
                            });
                        }


                        // Facebook is a weird one. These two actually need to combine
                        // to make one label/link
                        if (contactType == "Facebook URL") { imageIcon = "facebook.png"; }
                        if (contactType == "Facebook Name") { imageIcon = "facebook.png"; }

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


                        textStackLayout.Children.Add(title);
                        textStackLayout.Children.Add(description);

                        grid.Children.Add(image, 0, 0);
                        grid.Children.Add(textStackLayout, 1, 0);

                        contentStackLayout.Children.Add(grid);

                        ContactList.Children.Add(contentStackLayout);
                        ContactList.Children.Add(lineStackLayout);
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
            }
        }
    }
}
