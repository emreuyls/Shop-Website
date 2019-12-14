using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class ProductCategory
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int ProductsID { get; set; }
        public Products Products { get; set; }

        public int BrandID { get; set; }
        public Brand Brand { get; set; }



    }
}
