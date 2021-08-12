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
        AdminManager2 am2 = new AdminManager2(new EFAdminDAL2());
        RoleManager rm = new RoleManager(new EfRoleDAL());


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
            _auth2.AdminRegister2(dto.UserName, dto.Password, dto.RoleId);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpPost]
        public ActionResult UpdateRole(Admin2 admin2)
        {
            am2.AdminUpdateBL(admin2);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            var adminValue = am2.GetByID(id);

            am2.AdminDeleteBL(adminValue);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> valueadminrole = (from c in rm.GetRoles()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.RoleName,
                                                       Value = c.RoleId.ToString()

                                                   }).ToList();

            ViewBag.valueadmin = valueadminrole;

            var adminvalue = am2.GetByID(id);
            return View(adminvalue);
        }
    }
}