using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDAL());
        public ActionResult Index() //Verileri listelicez
        {
           var categoryValues= cm.GetList();
            return View(categoryValues);

        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
       [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator rules = new CategoryValidator();
            ValidationResult res = rules.Validate(category);
            if (res.IsValid)
            {
                cm.CategoryAdd(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = cm.GetById(id);
            cm.CategoryDelete(categoryvalues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryValue = cm.GetById(id);
         
            return View(categoryValue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            cm.CategoryUpdate(category);
            return RedirectToAction("Index");
        }
    }
}