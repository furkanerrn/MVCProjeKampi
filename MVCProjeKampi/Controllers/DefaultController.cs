using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{

    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager hm = new HeadingManager(new EfHeadingDAL());
        ContentManager cm = new ContentManager(new EfContentDAL());


        public ActionResult Headings()
        {
            var headings = hm.GetList();
            return View(headings);
        }
        public PartialViewResult Index(int id=0)
        {
            var contents = cm.GetListByHeadingId(id);
            return PartialView(contents) ;
        }
    }
}