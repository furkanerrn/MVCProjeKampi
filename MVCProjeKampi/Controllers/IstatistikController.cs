using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjeKampi.Controllers
{
    public class IstatistikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDAL());
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            // 1) Toplam kategori sayısı
            var query1 = context.Categories.Count();
            ViewBag.q1 = query1;
                   


            // 2) Yazılım alanına ait başlık sayısı *Yazılım ın id si 16
            var query2 = context.Headings.Count(x => x.CategoryId == 16);
            ViewBag.q2 = query2;


            // 3) Adında a harfi bulunan kişi sayısı
            var query3 = context.Writers.Count(x => x.UserName.Contains("a"));
            ViewBag.q3 = query3;


            // 4) En çok başlığa sahip kategori adı
            var query4 = context.Categories.Where(u => u.CategoryId == context.Headings.GroupBy(x => x.CategoryId).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.q4 = query4;


            // 5) Categorystatus'u true olanlarla false olanlar arasıdaki fark
            var query5 = context.Categories.Count(x => x.CategoryStatus == true) - context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.q5 = query5;


            return View();

        }
    }


}