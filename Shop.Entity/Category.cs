using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }       
        public string Picture { get; set; }
        public bool PrimaryCategory { get; set; }
        public bool SeconderyCategory { get; set; }
        public int SubCategory { get; set; }
        public List<ProductCategory> productCategories { get; set; }
    }
}
