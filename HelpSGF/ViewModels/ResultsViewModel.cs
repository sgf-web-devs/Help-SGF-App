using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HelpSGF.Models;
using HelpSGF.Models.Search;

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

            LocationSearchResultItems = new ObservableCollection<LocationSearchResultItem>();
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

        private ObservableCollection<LocationSearchResultItem> _locations;
        public ObservableCollection<LocationSearchResultItem> LocationSearchResultItems
        {
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        public string ResultsLabel
        {
            get
            {
                return LocationSearchResultItems.Count.ToString() + " Results";
            }
        }
    }
}
