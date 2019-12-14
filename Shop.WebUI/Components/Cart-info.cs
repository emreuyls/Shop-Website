using Microsoft.AspNetCore.Mvc;
using Shop.WebUI.Infrastructure;
using Shop.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.WebUI.Controllers
{
    public class Cart_info : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View(HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart());
        }
    }
}
