using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class ProductInformation
    {
        public int ID { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }

    }
}
