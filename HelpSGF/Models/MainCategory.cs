using System;
using System.Collections.Generic;

namespace HelpSGF.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string LocalImagePath { get; set; }
        public string RemoteImagePath { get; set; }
        public List<Category> SubCategories { get; set; }
        public string Name { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
    }
}
