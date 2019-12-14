using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;

namespace Shop.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork unitofwork;
        public HomeController(IUnitOfWork _unitofwork)
        {
            unitofwork = _unitofwork;
        }
        public IActionResult Index()
        {
            return View(unitofwork.Products.GetAll());
        }
    }
}