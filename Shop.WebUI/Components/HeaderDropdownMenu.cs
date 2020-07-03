using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Components
{
    public class HeaderDropdownMenu:ViewComponent
    {
        private ICategoryRepository repository;
        public HeaderDropdownMenu(ICategoryRepository _repository)
        {
            repository = _repository;
        }
        public IViewComponentResult Invoke()
        {

            return View(repository.Find(x=>x.PrimaryCategory||x.SeconderyCategory));
        }
    }
}
