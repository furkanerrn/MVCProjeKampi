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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EFSkillDAL());
        // GET: Skill
        public ActionResult Index()
        {
            var skillalues = skillManager.GetList();
            return View(skillalues);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Skill skill)
        {
            skillManager.SkillAdd(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSkill(int skillid)
        {
           var skillValues= skillManager.GetById(skillid);
            return View(skillValues);
        }
        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            skillManager.SkillUpdate(skill);
            return RedirectToAction("Index");
        }



    }
}