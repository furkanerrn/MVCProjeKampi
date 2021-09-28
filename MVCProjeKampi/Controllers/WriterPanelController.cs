using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;  //paging için gerekli 
using PagedList.Mvc; //paging için gerekli 

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel

        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        CategoryManager cm = new CategoryManager(new EfCategoryDAL());
        Context c = new Context();

        int id; 

        public ActionResult WriterProfile()
        {
            return View();
        }

        
        public ActionResult MyHeading(string p)
        {
           

            p = (string)Session["WriterMail"];
           var  writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
           
            var values = hm.GetListByWriter(writeridinfo);
           
           
            return View(values);

        }
        [HttpGet]
        public ActionResult NewHeading()
        {

            string deger = (string)Session["WriterMail"];
            ViewBag.m = deger;
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading h)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.id = writeridinfo;
            h.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            h.WriterId = writeridinfo;
            h.HeadingStatus = true;
            hm.HeadingAdd(h);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()

                                                  }
                                                 ).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetById(id);
            return View(headingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

       
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetById(id);
            headingvalue.HeadingStatus = false;
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("MyHeading");

        }

        public ActionResult AllHeading(int p=1) 
        {
            var headingvalues = hm.GetList().ToPagedList(p,5); //1 (p) değerinden başlayıp 4 tane değer göstersin
            return View(headingvalues);

            //daha sonra ilgili view ın modelinde bulunan List i PagingList'e çevrmeliyiz.
        }
    }
}