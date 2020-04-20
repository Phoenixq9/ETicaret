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
    public class UserController : Controller
    {
        private IGenericRepository<User> repository = null;

        public UserController()
        {
            this.repository = new GenericRepository<User>();
        }
        public UserController(IGenericRepository<User> repository)
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
        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditUSer(int UserId)
        {
            User model = repository.GetById(UserId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditEmployee(User model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "User");
            }
            //Add metodunda else yok bunda da olmazsa sayfa acılır mı deneyecegiz!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult DeleteUser(int UserId)
        {
            User model = repository.GetById(UserId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int UserID)
        {
            repository.Delete(UserID);
            repository.Save();
            return RedirectToAction("Index", "User");
        }
    }
}