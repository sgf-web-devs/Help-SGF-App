using System;
using HelpSGF.iOS.Renderers;
using HelpSGF.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MainPage), typeof(MainPageRenderer))]
namespace HelpSGF.iOS.Renderers
{
    public class MainPageRenderer : TabbedRenderer
    {
        readonly nfloat imageYOffset = 7.0f;

        public MainPageRenderer()
        {
            Console.WriteLine("Hellllo?");
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if(TabBar.Items != null)
            {
                foreach (var item in TabBar.Items)
                {
                    item.Title = null;
                    item.ImageInsets = new UIKit.UIEdgeInsets(imageYOffset, 0, -imageYOffset, 0);
                }
            }
        }
    }
}
