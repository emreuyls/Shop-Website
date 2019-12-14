using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Models
{
    public class ProductPageModel
    {
        public Products Products { get; set; }
        public List<Images> Images { get; set; }
        public List<Category> Categories { get; set; }
        public List<ProductInformation> productInformations { get; set; }
    }
}
