using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using Shop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Components
{
    public class CategorySideCategory : ViewComponent
    {
        private ICategoryRepository repository;
        public CategorySideCategory(ICategoryRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke(int id)
        {
            var category = repository.GetAll().Where(x => x.SubCategory == id);
            if (category.Any())
                return View(category);
            else
            {
                
                var model = repository.GetAll().Where(x => x.ID == id)
                     .Include(x => x.productCategories)
                     .ThenInclude(x => x.Brand)
                     .Select(x => new BrandModel()
                     {
                         Brands = x.productCategories.Select(a => a.Brand).ToList(),
                         CategoryID = id
                     }).First();
            return View("Brand", model);
            }

        }
    }
}
