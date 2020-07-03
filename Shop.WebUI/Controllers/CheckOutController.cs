using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.WebUI.Infrastructure;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class CheckOutController : Controller
    {
        public IActionResult Index()
        {


            return View(HttpContext.Session.GetJson<Cart>("Cart")??new Cart());
        }
    }
}