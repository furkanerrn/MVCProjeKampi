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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());

        // GET: Message
        public ActionResult Inbox()
        {
            var inbox = mm.GetListInBox();
            return View(inbox);

          
        }
        public ActionResult SendBox()
        {
            var sendbox = mm.GetListSendBox();
            return View(sendbox);
           
        }

       public ActionResult GetDraftMessages()
        {
            string session = (string)Session["AdminMail"];
            var trash = mm.IsDraft(session);
            return View(trash);
        }


       

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            return View();
        }


        ActionResult CountValue()
        {
            var query6 = mm.GetListInBox().Count();
            ViewBag.q6 = query6;

            var query7 = mm.GetListSendBox().Count();
            ViewBag.q7 = query7;


            return View();


           
        }




    }
}