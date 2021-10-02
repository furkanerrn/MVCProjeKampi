using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: MessagePanel
        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator mv = new MessageValidator();
        Context c = new Context();

        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messagelist = mm.GetListInBox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageList = mm.GetListSendBox(p);
            return View(messageList);
        }

        public ActionResult GetInboxMessagesDetails(int id)
        {
            var inbox = mm.GetById(id);
            return View(inbox);
        }

        public ActionResult GetSendboxMessagesDetails(int id)
        {
            var sendbox = mm.GetById(id);
            return View(sendbox);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SenderMail = sender;

            ValidationResult res = mv.Validate(p);


            if (res.IsValid)
            {
               
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in res.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}