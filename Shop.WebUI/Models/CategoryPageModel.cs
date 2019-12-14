using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Models
{
    public class CategoryPageModel
    {
        public List<Products> Products { get; set; }
        public int CategoryID { get; set; }
    }
}
