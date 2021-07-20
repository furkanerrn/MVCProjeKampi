using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

namespace MVCProjeKampi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin a)
        {
            string hashusername = a.UserName;
            MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

            byte[] usernamebyytes = System.Text.Encoding.UTF8.GetBytes(hashusername);
            byte[] MD5ComputeBytes = MD5.ComputeHash(usernamebyytes);
            string res=Convert.ToBase64String(MD5ComputeBytes);
            return View();
        }
    }
}