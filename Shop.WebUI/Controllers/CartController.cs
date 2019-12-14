using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;
using Shop.WebUI.Infrastructure;
using Shop.WebUI.Models;

namespace Shop.WebUI.Components
{
    public class CartController : Controller
    {
        private IProductRepository repository;
        public CartController(IProductRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index()
        {
            return View(GetCart());
        }
        public IActionResult AddToCart(int ProductID,int quantity=1)
        {
            var product = repository.Get(ProductID);
            
            if (product != null)
            {
                var cart = GetCart();
                cart.AddProduct(product, quantity);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int productID)
        {
            var product = repository.Get(productID);
            if(product != null)
            {
                var cart = GetCart();
                cart.RemoveProduct(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index");
        }

        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart", cart);
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        }
    }
}