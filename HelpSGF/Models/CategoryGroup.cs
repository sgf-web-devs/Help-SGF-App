using System;
using System.Collections.ObjectModel;

namespace HelpSGF.Models
{
    public class CategoryGroup : ObservableCollection<Category>
    {
        public string LongName { get; set; }
        public string ShortName { get; set; }
    }
}
