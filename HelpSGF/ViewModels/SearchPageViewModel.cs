using System;
using System.Collections.Generic;
using HelpSGF.Models;

namespace HelpSGF.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public SearchPageViewModel()
        {
        }

        private List<MainCategory> _categories;
        public List<MainCategory> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }
    }
}
