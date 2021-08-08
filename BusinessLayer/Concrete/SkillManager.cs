using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager : SkillService
    {
        ISkillDAL _skillDal;

        public SkillManager(ISkillDAL skillDal)
        {
            _skillDal = skillDal;
        }

        public Skill GetById(int id)
        {
            return _skillDal.Get(x => x.SkillCardId == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List();
        }

        public void SkillAdd(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            _skillDal.Delete(skill);
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
