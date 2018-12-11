using System;
using CoreGraphics;
using HelpSGF;
using HelpSGF.iOS.Renderers;
using HelpSGF.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HelpSGFSearchBar), typeof(SearchBarWithNoBarRenderer))]
namespace HelpSGF.iOS.Renderers
{
    public class SearchBarWithNoBarRenderer : SearchBarRenderer
    {
        public SearchBarWithNoBarRenderer()
        {
            Console.WriteLine("Hellllo SearchBarWithNoBarRenderer?");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            UISearchBar bar = (UISearchBar)this.Control;

            bar.Layer.BorderWidth = 1;
            bar.Layer.BorderColor = UIColor.FromRGB(180, 226, 217).CGColor;
        }
    }
}
