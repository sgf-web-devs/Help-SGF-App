using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HelpSGF.Models;
using HelpSGF.Services;

namespace HelpSGF.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        private Dictionary<string, int> _categories;  // for xaml binding
        public Dictionary<string, int> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private string _mainCategoryName;  // for xaml binding
        public string MainCategoryName
        {
            get { return _mainCategoryName; }
            set
            {
                _mainCategoryName = value;
                OnPropertyChanged();
            }
        }

        public CategoriesViewModel()
        {
            //Task.Run(async () => {
            //    await InitializeData();
            //});
        }
    }
}
