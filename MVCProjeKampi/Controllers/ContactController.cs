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
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactDAL());
        MessageManager mm = new MessageManager(new EFMessageDAL());
        Context c = new Context();
       
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

            var sendMail = mm.GetListSendBox("furkan@gmail.com").Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInBox("furkan@gmail.com").Count();
            ViewBag.receiverMail = receiverMail;

            var taslak = mm.IsDraft().Count();
            ViewBag.taslak = taslak;

            var values = c.Messages.Count(x => x.IsRead == false && x.ReceiverMail == "admin@gmail.com");
            ViewBag.values = values;

            var values2 = c.Messages.Count(x => x.IsRead == true && x.ReceiverMail == "admin@gmail.com");
            ViewBag.values2 = values2;

            return PartialView();
        }



    }
}