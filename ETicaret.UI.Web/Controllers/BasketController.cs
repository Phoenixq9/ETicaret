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
    public class BasketController : Controller
    {
        private IGenericRepository<Basket> repository = null;

        public BasketController()
        {
            this.repository = new GenericRepository<Basket>();
        }
        public BasketController(IGenericRepository<Basket> repository)
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
        public ActionResult AddBasket()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBasket(Basket model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Baket");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditBasket(int BasketId)
        {
            var model = repository.GetById(BasketId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditBasket(Basket model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Basket");
            }
           
                return View(model);
            
        }
        [HttpGet]
        public ActionResult DeleteBasket(int BasketId)
        {
            var model = repository.GetById(BasketId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int BasketId)
        {
            repository.Delete(BasketId);
            repository.Save();
            return RedirectToAction("Index", "Baket");
        }
    }
}