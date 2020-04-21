
using ETicaret.Business.GenericRepository.Interface;
using ETicaret.Business.GenericRepository.Repository;
using ETicaret.DataAccess.ORM.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaret.UI.Web.Controllers
{
    public class UserAddressController : Controller
    {
        private IGenericRepository<UserAddress> repository = null;

        public UserAddressController()
        {
            this.repository = new GenericRepository<UserAddress>();
        }
        public UserAddressController(IGenericRepository<UserAddress> repository)
        {
            this.repository = repository;
        }


        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddUserAdress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUserAdress(UserAddress model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "UserAddress");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditUserAddress()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult EditUserAddress(UserAddress model, int UserAddressId)
        {
            if (ModelState.IsReadOnly)
            {
                model = repository.GetById(UserAddressId);
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "UserAddress");
            }
            return View(model);
        }

         //Dogru calısacak mı kontrol et!!!!!!!!
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int UserAddressId)
        {
            var model = repository.GetById(UserAddressId);
            repository.Delete(model);
            repository.Save();
            return RedirectToAction("Index", "UserAddress");
        }
    }
}