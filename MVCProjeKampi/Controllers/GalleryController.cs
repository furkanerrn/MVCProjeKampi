using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EFImageFileDAL());

        // GET: Gallery
        public ActionResult Index()
        {
            var images = im.GetList();
            return View(images);
        }
    }
}