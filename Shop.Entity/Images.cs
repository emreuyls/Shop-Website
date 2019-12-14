using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Entity
{
   public class Images
    {
        public int ID { get; set; }
        public int ProductsID { get; set; }
        public Products Products { get; set; }
        public string ImageName { get; set; }
    }
}
