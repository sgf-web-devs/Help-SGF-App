using System;
using System.Collections.Generic;
using HelpSGF.Models;
using HelpSGF.Views;
using HelpSGF.ViewModels;

using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage(string topLevelCategoryName)
        {
            InitializeComponent();

            // Haxors for cleanr looking title until proper structure is in palce
            var _title = topLevelCategoryName.Replace("_", " ");

            Title = UppercaseWords(_title);

            NavigationPage.SetBackButtonTitle(this, "");

            BindingContext = viewModel = new CategoriesViewModel();
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new LocationsPage(new ResultsViewModel()));
        }

        static string UppercaseWords(string value)
        {
            char[] array = value.ToCharArray();
            // Handle the first letter in the string.
            if (array.Length >= 1)
            {
                if (char.IsLower(array[0]))
                {
                    array[0] = char.ToUpper(array[0]);
                }
            }
            // Scan through the letters, checking for spaces.
            // ... Uppercase the lowercase letters following spaces.
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] == ' ')
                {
                    if (char.IsLower(array[i]))
                    {
                        array[i] = char.ToUpper(array[i]);
                    }
                }
            }
            return new string(array);
        }
    }

}
