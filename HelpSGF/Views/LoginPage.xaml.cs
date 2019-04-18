using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HelpSGF.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        void Login_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new SendMessagePage());
        }
    }
}
