using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface SkillService
    {

        void SkillAdd(Skill skill);
        void SkillDelete(Skill skill);
        void SkillUpdate(Skill skill);
        Skill GetById(int id);

        List<Skill> GetList();
    }
}
