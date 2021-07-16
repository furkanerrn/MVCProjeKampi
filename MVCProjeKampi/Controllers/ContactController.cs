using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDAL());
        MessageManager mm = new MessageManager(new EFMessageDAL());
        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = cm.GetById(id);
            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendBox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInBox().Count();
            ViewBag.receiverMail = receiverMail;

            return PartialView();
        }



    }
}