using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelpSGF.Views;
using PCLAppConfig;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelpSGF
{
    public partial class App : Application
    {

        public App()
        {
            ConfigurationManager.Initialise(PCLAppConfig.FileSystemStream.PortableStream.Current);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("A_KEY_GOES_HERE");

            InitializeComponent();


            MainPage = new MainPage();

            //var navigationPage = new NavigationPage(MainPage)
            {
                //BarBackgroundColor = Color.LightGreen,
                //BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
