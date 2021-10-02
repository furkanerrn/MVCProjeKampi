using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using DataAccessLayer.Concrete.Repositories;
using System.Web.Security;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Dto;

namespace MVCProjeKampi.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDAL());
        IAuthService2 _auth = new AuthManager2(new AdminManager2(new EFAdminDAL2()));
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Index(AdminDto dto)
        {

            if (_auth.AdminLogin2(dto))
            {
                FormsAuthentication.SetAuthCookie(dto.UserName, false);
                Session["AdminUserName"] = dto.UserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.error= "Kullanıcı adı veya Parola yanlış";
                return View();
            }


        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword==p.WriterPassword);
            //Writer Login işlemini Kurumsal Mimariye taşıdık.
            //
            var writeruserInfo = wm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserInfo!=null)
            {
                FormsAuthentication.SetAuthCookie(p.WriterMail, false);
              var a=  Session["WriterMail"] = p.WriterMail;
                ViewBag.mail = a;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.error2 = "Mail veya Parola yanlış. Lütfen tekrar deneyiniz";
                return View();
            }

            //if (_auth.AdminLogin2(p))
            //{
            //    FormsAuthentication.SetAuthCookie(p.UserName, false);
            //    Session["AdminUserName"] = p.UserName;
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            //else
            //{
            //    ViewBag.error = "Kullanıcı adı veya Parola yanlış";
            //    return View();
            //}
            //return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

       
    }
}