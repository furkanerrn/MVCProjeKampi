﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
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
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryManager cm = new CategoryManager(new EfCategoryDAL());
         
       
  
        public ActionResult Index()
        {
            return View();
        }
         
        [HttpGet]
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();
           
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {

            return View();
            
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            //  CategoryManager.CategoryAddBL(category);
            //cm.CategoryAdd(category);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                cm.CategoryAdd(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                    
                }
               
            }
            return View();
            
        }
    }
}