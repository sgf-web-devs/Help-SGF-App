using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace HelpSGF.ViewModels
{
    public class ResultsViewModel : BaseViewModel
    {
        public ResultsViewModel()
        {
            Filters = new ObservableCollection<string>
            {
                "Veteran", "Laundry", "LGTBW"
            };
        }

        private ObservableCollection<string> _filters;

        public ObservableCollection<string> Filters
        {
            get => _filters;
            set
            {
                _filters = value;
                OnPropertyChanged();
            }
        }
    }
}
