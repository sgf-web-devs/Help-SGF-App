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
        private List<Category> _categories;  // for xaml binding
        public List<Category> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        private MainCategory _category;  // for xaml binding
        public MainCategory MainCategory
        {
            get { return _category; }
            set
            {
                _category = value;
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
