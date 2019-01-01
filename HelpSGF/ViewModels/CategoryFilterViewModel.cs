using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using HelpSGF.Models;
using HelpSGF.Services;

namespace HelpSGF.ViewModels
{
    public class CategoryFilterViewModel : INotifyPropertyChanged
    {
        MockDataCalls dataService = new MockDataCalls();


        private ObservableCollection<CategoryGroup> _categories;  // for xaml binding
        public ObservableCollection<CategoryGroup> Categories
        {
            get { return _categories; }
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public CategoryFilterViewModel()
        {
            Task.Run(async () => {
                await InitializeData();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task InitializeData()
        {
            try
            {
                IsBusy = true; // set the ui property "IsRunning" to true(loading) in Xaml ActivityIndicator Control
                Categories = await dataService.GetSubCategoriesAsync();
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isBusy;   // for showing loader when the task is initializing
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
    }
}
