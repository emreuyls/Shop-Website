using Shop.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Models
{
   public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;
        public void AddProduct(Products product,int quantity)
        {
            var prd = products.Where(i => i.Products.ID == product.ID).FirstOrDefault();

            if (prd == null)
            {
                Products.Add(new CartLine()
                {
                    Products=product,
                    Quantity=quantity
                });
            }
            else
            {
                prd.Quantity += quantity;
            }
        }
        public void RemoveProduct(Products product)
        {
            products.RemoveAll(x=>x.Products.ID==product.ID);
        }

        public decimal TotalPrice()
        {
            return products.Sum(i => i.Products.UnitPrice * i.Quantity);
        }
        public void ClearAll()
        {
            products.Clear();
        }
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
    }
}
