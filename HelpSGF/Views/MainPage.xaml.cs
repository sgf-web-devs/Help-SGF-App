using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelpSGF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            BarBackgroundColor = Color.Black;
            BarTextColor = Color.White;
            InitializeComponent();
        }
    }
}