using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
    public class Brand
    {
        public int ID { get; set; }
        public string BrandName { get; set; }     
        public List<ProductCategory> productCategories { get; set; }
    }
}
