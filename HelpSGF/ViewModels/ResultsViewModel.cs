using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HelpSGF.Models;

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

            Locations = new ObservableCollection<Location>();
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

        private ObservableCollection<Location> _locations;
        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        private readonly string _resultsLabel;
        public string ResultsLabel
        {
            get
            {
                return Locations.Count.ToString() + " Results";
            }
        }
    }
}
