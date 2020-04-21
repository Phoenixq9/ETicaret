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
    public class ProductController : Controller
    {
        private IGenericRepository<Product> repository = null;

        public ProductController()
        {
            this.repository = new GenericRepository<Product>();
        }
        public ProductController(IGenericRepository<Product> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        public ActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Product");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditProduct(int ProductId)
        {
            var model = repository.GetById(ProductId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Product");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteProduct(int ProductId)
        {
            var model = repository.GetById(ProductId);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Product model)
        {
            repository.Delete(model);
            repository.Save();
            return RedirectToAction("Index", "Product");
        }
    }
}