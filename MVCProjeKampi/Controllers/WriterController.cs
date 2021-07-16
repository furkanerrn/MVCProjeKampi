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
    public class WriterController : Controller
    {
        // GET: Writer
        WriterValidator writerValidator = new WriterValidator();
        WriterManager writerManager = new WriterManager(new EfWriterDAL());
        public ActionResult Index()
        {
            var writerValues = writerManager.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            
            ValidationResult res= writerValidator.Validate(writer);

            if (res.IsValid)
            {
                writerManager.WriterAdd(writer);
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
        [HttpGet]
        public ActionResult EditWriter(int id) {
            var writerValue = writerManager.getById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult res = writerValidator.Validate(writer);


            writerManager.WriterUpdate(writer);
            return RedirectToAction("Index");
            //if (res.IsValid)
            //{
            //}
            //else
            //{
            //    foreach (var item in res.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
           
           // return View(); 
        }
    }
}