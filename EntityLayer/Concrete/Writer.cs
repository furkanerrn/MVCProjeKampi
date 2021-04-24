using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
       
        [Key]
        public int WriterId { get; set; }

        [StringLength(20)] 
        public string UserName { get; set; }

        [StringLength(20)]
        public string WriterSurname { get; set; }
       
        [StringLength(50)]
        public string WriterMail { get; set; }

        [StringLength(1000)]
        public string WriterImage { get; set; }
        [StringLength(15)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; } //Heading sınıfıyla bağlantı
        public ICollection<Content> Contents { get; set; }
    }
}
