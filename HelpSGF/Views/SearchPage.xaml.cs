using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class SearchPage : ContentPage
    {
        void Handle_Clicked(Button sender, System.EventArgs e)
        {
            var value = sender.CommandParameter;

        }

        public SearchPage()
        {
            InitializeComponent();
        }
    }
}
