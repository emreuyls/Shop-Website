using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IUnitOfWork repository;
        
        public ProductController(IUnitOfWork _repository)
        {
            repository = _repository;
        }        
        public IActionResult Index(string productname, string stockcode)
        {

          
            return View(repository.Products.GetAll()
                .Where(x=>x.StockCode== stockcode)
                .Include(x=>x.Images)
                .Include(x=>x.ProductInformations)
                .Include(x=>x.ProductCategories)
                .ThenInclude(x=>x.Category).Select(x=>new ProductPageModel()
                {
                    Products=x,
                    Images=x.Images,
                    productInformations=x.ProductInformations,
                    Categories=x.ProductCategories.Select(a=>a.Category).ToList(),

                }).FirstOrDefault());
        }
    }
}