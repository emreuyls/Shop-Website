using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private IUnitOfWork repository;
        public CategoryController(IUnitOfWork _repository)
        {
            repository = _repository;
        }

        public IActionResult Index(int id)
        {
            var model = repository.Category.GetAll().Where(x =>(x.SubCategory != id) ?x.ID== id : x.SubCategory== id)
                .Include(x => x.productCategories)
                .ThenInclude(x => x.Products)
                .Select(x => new CategoryPageModel()
                {
                    Products = x.productCategories.Select(a => a.Products).ToList(),
                    CategoryID = (x.SubCategory==id)?x.SubCategory:x.ID
                }).FirstOrDefault();
            return View(model);
        }
        public IActionResult SubCategory(string category)
        {

            return View();
        }
    }
}