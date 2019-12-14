using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Components
{
   
   
    public class SideCategoryMenu:ViewComponent
    { private ICategoryRepository repository;
        public SideCategoryMenu(ICategoryRepository _repository)
        {
            repository = _repository;
        }

        public IViewComponentResult Invoke()
        {
            
            return View(repository.Find(x=>x.PrimaryCategory||x.SeconderyCategory));
        }

    }
}
