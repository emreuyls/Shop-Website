using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Models
{
    public class BrandModel
    {
        public List<Brand> Brands { get; set; }
        public int CategoryID { get; set; }
    }
}
