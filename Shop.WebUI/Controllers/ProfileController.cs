using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.Entity;
using Shop.WebUI.IdentityCore;
using Shop.WebUI.Models;

namespace Shop.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUnitOfWork repository;
        UserManager<ApplicationUser> userManager;
        public ProfileController(IUnitOfWork repo, UserManager<ApplicationUser> _usermanager)
        {
            repository = repo;
            userManager = _usermanager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Account()
        {


            var id = userManager.GetUserId(User);
            var users = repository.Customer.Find(x => x.UserID == id).FirstOrDefault();
            if (users != null)
            {
                var model = new AccountModels()
                {
                    Name = users.Name,
                    SurName = users.SurName,
                    Email = users.Email,
                    Phone = users.Phone,
                    Gender = users.Gender
                };
                return View(model);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Account(AccountModels model)
        {
            if (model != null)
            {
                var id = userManager.GetUserId(User);
                var users = repository.Customer.Find(x => x.UserID == id).FirstOrDefault();
                if (users != null)
                {
                    users.Name = model.Name;
                    users.SurName = model.SurName;
                    users.Gender = model.Gender;
                    users.Phone = model.Phone;
                    if (users.Email != model.Email)
                    {
                        var changeUser = await userManager.FindByIdAsync(id);
                        var user = await userManager.FindByEmailAsync(model.Email);
                        if (user == null)
                        {
                            changeUser.Email = model.Email;
                            await userManager.UpdateAsync(changeUser);
                            users.Email = model.Email;
                        }
                        else
                        {
                            ModelState.AddModelError("Email", "Eposta Adresi Kullanılıyor.");
                            return View(model);
                        }
                    }
                    repository.Customer.Update(users);
                    TempData["Success"] = "Bilgileriniz Güncellenmiştir.";
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult Adress()
        {
            var id = userManager.GetUserId(User);
            var user = repository.Customer.Find(x => x.UserID == id).FirstOrDefault();
            var model = repository.Adress.GetAll().Where(x => x.UserID == user.ID).Select(a => new AdressModel()
            {
                Adress1 = a.Adress1,
                ID = a.ID,
                City = a.City,
                Names = a.Names,
                Phone = a.Phone,
                State = a.State,
                Title = a.AdressTitle
            }).ToList();

            return View(model);
        }
        [HttpPost]
        public IActionResult Adress(AdressModel model)
        {
            return View();
        }
        [HttpGet]
        public IActionResult AdressDetails(int? id)
        {
            var model = repository.Adress.Find(x => x.ID == id).FirstOrDefault();
            return PartialView(model);
        }
        [HttpPost]
        public IActionResult AdressDetails(Adress model)
        {
            if (ModelState.IsValid)
            {
                if (model.ID == 0)
                {
                    var id = userManager.GetUserId(User);
                    var otherid = repository.Customer.Find(x => x.UserID == id).FirstOrDefault();
                    model.UserID = otherid.ID;
                    repository.Adress.Create(model);
                    return RedirectToAction("Adress");
                }
                else
                {

                    int control = repository.Adress.Update(model);
                    if (control == 1)
                    {
                        return RedirectToAction("Adress");
                    }


                }
            }
            return PartialView(model);

        }

        [HttpGet]
        public IActionResult NewAdress()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult NewAdress(AdressModel model)
        {
            var id = userManager.GetUserId(User);
            var userid = repository.Customer.Find(x => x.UserID == id).FirstOrDefault();
            if (ModelState.IsValid)
            {
                var adress = new Adress()
                {
                    Adress1 = model.Adress1,
                    AdressTitle = model.Title,
                    City = model.City,
                    State = model.State,
                    UserID = userid.ID,
                    Names = model.Names,
                    Phone = model.Phone,
                    BillingAdress = model.BillingAdress,
                    BillingCity = model.BillingCity,
                    BillingState = model.BillingState
                };
                if (model.BillingCheck)
                {
                    adress.BillingAdress = model.Adress1;
                    adress.BillingCity = model.City;
                    adress.BillingState = model.State;
                }
                int control = repository.Adress.Create(adress);
                if (control >= 1)
                {
                    TempData["Success"] = "Adress Başarıyla Oluşturuldu";
                    return Json(new {success=true});
                    //TODO: return oluyor ama arka planda modal acık olduğu için patladığını düşünüyorum
                }
            }
            return Json(new { success = false,data=model,errors=ModelState.Values.Where(i=>i.Errors.Count>0) });

        }
        public IActionResult AdressDelete(int? id)
        {
            var adress = repository.Adress.Find(x => x.ID == id).FirstOrDefault();
            if (adress != null)
            {
                int control = repository.Adress.Delete(adress);
                if (control >= 1)
                {
                    TempData["Success"] = "Adresiniz Başarı ile Kaldırılmıştır";
                    return RedirectToAction("Adress");
                }
                else
                {
                    TempData["Warning"] = "Adres Kaldırma Başarısız Oldu";
                    return RedirectToAction("Adress");

                }
            }
            TempData["Warning"] = "Opps Bir Sorun Oluştu";
            return RedirectToAction("Adress");
        }


    }
}