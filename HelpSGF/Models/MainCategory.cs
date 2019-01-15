using System;
using System.Collections.Generic;

namespace HelpSGF.Models
{
    public class MainCategory
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}
