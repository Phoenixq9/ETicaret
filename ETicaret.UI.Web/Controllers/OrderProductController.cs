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
    public class OrderProductController : Controller
    {
        private IGenericRepository<OrderProduct> repository = null;

        public OrderProductController()
        {
            this.repository = new GenericRepository<OrderProduct>();
        }
        public OrderProductController(IGenericRepository<OrderProduct> repository)
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
        public ActionResult AddOrderProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddOrderProduct(OrderProduct model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return View("Index", "Product");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditOrderProduct(int OrderProductId)
        {
            var model = repository.GetById(OrderProductId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditOrderProduct(OrderProduct model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "OrderProduct");
            }
            return View();
        }
        [HttpGet]
        
        public ActionResult DeleteProduct(int OrderProductId)
        {
            var model = repository.GetById(OrderProductId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int OrderProductId)
        {
            repository.Delete(OrderProductId);
            repository.Save();
            return RedirectToAction("Index", "OrderProduct");
        }
    }
    }
