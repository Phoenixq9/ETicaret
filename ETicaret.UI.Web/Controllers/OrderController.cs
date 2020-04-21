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
    public class OrderController : Controller
    {
        public IGenericRepository<Order> repository = null;
        public OrderController()
        {
            this.repository = new GenericRepository<Order>();
        }
        public OrderController (GenericRepository<Order> repository)
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
        public ActionResult AddOrder()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(Order model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Order");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditOrder(int OrderId)
        {
            var model = repository.GetById(OrderId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditOrder(Order model)
        {
            if (ModelState.IsReadOnly)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Order");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteOrder(int OrderId)
        {
            var model = repository.GetById(OrderId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int OrderId)
        {
            repository.Delete(OrderId);
            repository.Save();
            return RedirectToAction("Index", "Order");
        }
    }
}