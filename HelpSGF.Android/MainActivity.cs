using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.Content;
using Android;
using Android.Support.V4.App;

namespace HelpSGF.Droid
{
    [Activity(Label = "Help SGF", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;


            global::Xamarin.FormsMaps.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());
        }
    }
}