using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDAL());
        // GET: WriterPanelContent
        public ActionResult MyContent()
        {
            Context c = new Context();

            string p = (string)Session["WriterMail"].ToString(); //tekrar dene
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            var contentvalues = cm.GetListByWriter(writeridinfo);
            return View(contentvalues);

            

            //var contentvalues = cm.GetListByWriter(writeridinfo);

        }
    }
}