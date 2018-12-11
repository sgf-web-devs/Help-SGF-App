using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelpSGF.ViewModels
{
    public class MainPageViewModel
    {
        public MainPageViewModel()
        {
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>((text) =>
                {
                    Console.WriteLine("Searched for " + text);
                }));
            }
        }

    }
}
