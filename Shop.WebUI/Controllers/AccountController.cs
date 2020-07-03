using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using Shop.WebUI.IdentityCore;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signinManager;
        private IUnitOfWork repository;

        public AccountController(UserManager<ApplicationUser> _usermanager, SignInManager<ApplicationUser> _signinmanager, IUnitOfWork repo)
        {
            userManager = _usermanager;
            signinManager = _signinmanager;
            repository = repo;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnurl)
        {
            ViewBag.returnurl = returnurl;
            return View();
        }
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModels model, string returnurl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signinManager.SignOutAsync();
                    var result = await signinManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnurl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Hatalı Eposta Veya Şifre");
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.Email = model.Email;
                user.Surname = model.Surname;
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var reguser = userManager.Users.Where(x => x.Email == user.Email).FirstOrDefault();
                    if(reguser!=null)
                    {
                        repository.Customer.Create(new Customers()
                        {
                            UserID = reguser.Id,
                            Name = reguser.Name,
                            SurName = reguser.Surname,
                            Email = reguser.Email //TODO:burada email çakışması olabilir...
                        });
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(model);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}