using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDAL());
        MessageValidator mv = new MessageValidator();

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
           
            var draft = mm.IsDraft();
            return View(draft);
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
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
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