using System;
using System.Collections.Generic;
using HelpSGF.Models;
using HelpSGF.Views;
using HelpSGF.ViewModels;

using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class CategoryFilterPage : ContentPage
    {
        CategoryFilterViewModel viewModel;

        public CategoryFilterPage()
        {
            InitializeComponent();

            Title = "Filter";

            //NavigationPage.SetBackButtonTitle(this, "");

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Done",
                Command = new Command(() =>
                {
                    Navigation.PopModalAsync();
                })
            });

            BindingContext = viewModel = new CategoryFilterViewModel();
        }
    }
}
