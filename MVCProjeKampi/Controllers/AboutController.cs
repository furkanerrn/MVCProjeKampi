using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EfAboutDAL());
        public ActionResult Index()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About a)
        {
            abm.AboutAdd(a);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult EditAbout(About a)
        {
            abm.AboutUpdate(a);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            if (aboutValue.IsActive==true)
            {
                aboutValue.IsActive = false;
               
            }
            else
            {
                aboutValue.IsActive = true;
                abm.AboutDelete(aboutValue);
            }

            abm.AboutDelete(aboutValue);
            return RedirectToAction("Index");
        }

        public ActionResult ActiveAbout(int id)
        {
            var aboutValue = abm.GetById(id);
            if (aboutValue.IsActive==false)
            {
                aboutValue.IsActive = true;
            }
            return RedirectToAction("Index");
        }
    }
}