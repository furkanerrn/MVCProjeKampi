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
    public class LoginController : Controller
    {
        IAuthService2 _auth = new AuthManager2(new AdminManager2(new EFAdminDAL2()));
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
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


    }
}