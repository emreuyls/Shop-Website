using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Components
{
    public class NewArrivalsSlider:ViewComponent
    {
        private IProductRepository repository;
        public NewArrivalsSlider(IProductRepository _repository)
        {
            repository = _repository;
        }
        public IViewComponentResult Invoke()
        {
            return View(repository.GetNewArrivals());
        }
    }
}
