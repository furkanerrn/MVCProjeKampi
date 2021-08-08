using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
     public class Skill:IEntity  //talent card
    {
        [Key]
        public int SkillCardId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
        public string Text { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public string SkillName1 { get; set; }
        public int SkillStage1 { get; set; }

        public string SkillName2 { get; set; }
        public int SkillStage2 { get; set; }

        public string SkillName3 { get; set; }
        public int SkillStage3 { get; set; }

        public string SkillName4 { get; set; }
        public int SkillStage4 { get; set; }

        public string SkillName5 { get; set; }
        public int SkillStage5 { get; set; }

        public string SkillName6 { get; set; }
        public int SkillStage6 { get; set; }

        public string SkillName7 { get; set; }
        public int SkillStage7 { get; set; }

        public string SkillName8 { get; set; }
        public int SkillStage8 { get; set; }

        public string SkillName9 { get; set; }
        public int SkillStage9 { get; set; }

        public string SkillName10 { get; set; }
        public int SkillStage10 { get; set; }

       



      
    }
}
