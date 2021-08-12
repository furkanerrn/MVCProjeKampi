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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager headingManager = new HeadingManager(new EfHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDAL());
        WriterManager writerManager = new WriterManager(new EfWriterDAL());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public ActionResult AddHeading( )
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                     Text=x.CategoryName,
                                                     Value=x.CategoryId.ToString()

                                                  }
                                                  ).ToList() ;
           List<SelectListItem> valuewriter=(from x in writerManager.GetList()
                                                 select new SelectListItem
                                                  {
                                                  Text=x.UserName+" "+x.WriterSurname,
                                                  Value=x.WriterId.ToString()
                                                  }).ToList();


            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valuewriter;

           return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {/*DB'ye tarih otomaitik olark veriliyo*/
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(heading);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()

                                                  }
                                                 ).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }

        public ActionResult EditHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);
            if (headingValue.HeadingStatus==true)
            {
                headingValue.HeadingStatus = false;
            }
            else
            {
                headingValue.HeadingStatus = true;
            }
           
            headingManager.HeadingDelete(headingValue);
            return RedirectToAction("Index");


        }

       
    }
}