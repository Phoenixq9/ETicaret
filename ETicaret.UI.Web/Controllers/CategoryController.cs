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
    public class CategoryController : Controller
    {
        private IGenericRepository<Category> repository = null;

        public CategoryController()
        {
            this.repository = new GenericRepository<Category>();
        }
        public CategoryController(IGenericRepository<Category> repository)
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
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditCategory(int CategoryId)
        {
            var model = repository.GetById(CategoryId);
            return View(model);
        }
        [HttpPost]
        public ActionResult EditCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteCategory(int CategoryId)
        {
            var model = repository.GetById(CategoryId);
            return View(model);
        }
        [HttpPost]
       
           public ActionResult Delete(int CategoryId)
        {
            repository.Delete(CategoryId);
            repository.Save();
            return RedirectToAction("Index", "Category");
        }
    }

    }
