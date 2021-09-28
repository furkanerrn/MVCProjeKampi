using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContentController : Controller
    {
        Context c = new Context();
        ContentManager contentManager = new ContentManager(new EfContentDAL());
        public ContentController()
        {
                
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContentbyHeading(int id )
        {
           
            var contentValues = contentManager.GetListByHeadingId(id);
            
            return View(contentValues);
        }
    }
}