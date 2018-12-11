using System;
using HelpSGF.iOS.Renderers;
using HelpSGF.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SearchPage), typeof(SearchPageRenderer))]
namespace HelpSGF.iOS.Renderers
{
    public class SearchPageRenderer : PageRenderer
    {

        public SearchPageRenderer()
        {
            Console.WriteLine("Hellllo SearchPageRenderer?");
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.NavigationController.NavigationBar.BackgroundColor = UIColor.Black;
            this.NavigationController.NavigationBar.BarTintColor = UIColor.Black;
            this.NavigationController.NavigationBar.TintColor = UIColor.Black;    
        }
    }
}
