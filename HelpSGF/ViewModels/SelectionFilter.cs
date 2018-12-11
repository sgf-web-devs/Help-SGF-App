using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelpSGF.ViewModels
{
    public class SelectionFilter : BaseViewModel
    {
        private List<string> _filters;

        public List<string> Filters
        {
            get => _filters;
            set
            {
                _filters = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectFilterCommand => new Command(filter => { });

        public SelectionFilter()
        {
            Filters = new List<string>
            {
                "Veteran", "Laundry", "LGTBW"
            };
        }


    }
}
