using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class AuthController : Controller
    {
        IAuthService2 _auth2 = new AuthManager2(new AdminManager2(new EFAdminDAL2()));

       

        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminDto dto)
        {
            _auth2.AdminRegister2(dto.UserName,dto.Password,dto.RoleId);
            return RedirectToAction("Index","AdminCategory");
        }
    }
}