using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HelpSGF.Models;

namespace HelpSGF.Services
{
    public class MockDataCalls
    {
        public MockDataCalls()
        {
        }

        public async Task<List<Category>> GetParentCategoriesAsync()
        {
            var cateogries = new List<Category>();

            var mockCategories = new List<Category>
            {
                new Category { Id = "1", Name = "Children" },
                new Category { Id = "2", Name = "LGBTQ" },
                new Category { Id = "3", Name = "Men" },
                new Category { Id = "4", Name = "Seniors" },
                new Category { Id = "5", Name = "Women" },
                new Category { Id = "6", Name = "Veteran" },
                new Category { Id = "7", Name = "Age 0-5" },
                new Category { Id = "8", Name = "Age 6-18" },
                new Category { Id = "9", Name = "Age 19-65" },
                new Category { Id = "10", Name = "Age 65+" }
            };

            foreach (var category in mockCategories)
            {
                cateogries.Add(category);
            }

            return await Task.FromResult(cateogries);
        }

        public async Task<ObservableCollection<CategoryGroup>> GetSubCategoriesAsync()
        {
            var cateogries = new ObservableCollection<CategoryGroup>();

            var clothingParent = new CategoryGroup { LongName = "Clothing", ShortName = "C" };
            var transportationParent = new CategoryGroup { LongName = "Transportation", ShortName = "T" };
            var byPersonParent = new CategoryGroup { LongName = "By Person", ShortName = "P" };


            var clothingCategories = new List<Category>
            {
                new Category { Id = "1", Name = "New/Used Clothes", ParentCategoryName = "Clothing" },
                new Category { Id = "2", Name = "Laundry", ParentCategoryName = "Clothing" }
            };

            var transportationCategories = new List<Category>
            {
                new Category { Id = "1", Name = "Bus Passes", ParentCategoryName = "Transportation" },
                new Category { Id = "2", Name = "Gas Voucher", ParentCategoryName = "Transportation" },
                new Category { Id = "3", Name = "Direct Transportation", ParentCategoryName = "Transportation" }
            };

            var byPersonCategories = new List<Category>
            {
                new Category { Id = "1", Name = "Children", ParentCategoryName = "By Person" },
                new Category { Id = "2", Name = "LGBTQ", ParentCategoryName = "By Person" },
                new Category { Id = "3", Name = "Men", ParentCategoryName = "By Person" },
                new Category { Id = "4", Name = "Seniors", ParentCategoryName = "By Person" },
                new Category { Id = "5", Name = "Women", ParentCategoryName = "By Person" }
            };

            foreach (var category in clothingCategories)
            {
                clothingParent.Add(category);
            }

            foreach (var category in transportationCategories)
            {
                transportationParent.Add(category);
            }

            foreach (var category in byPersonCategories)
            {
                byPersonParent.Add(category);
            }

            cateogries.Add(clothingParent);
            cateogries.Add(transportationParent);
            cateogries.Add(byPersonParent);

            return await Task.FromResult(cateogries);
        }
    }
}
