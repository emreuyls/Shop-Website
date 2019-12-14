using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop.WebUI.IdentityCore;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signinManager;

        public AccountController(UserManager<ApplicationUser> _usermanager, SignInManager<ApplicationUser> _signinmanager)
        {
            userManager = _usermanager;
            signinManager = _signinmanager;
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
                    return RedirectToAction("Index", "Home");

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