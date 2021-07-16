﻿using System;
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

        [StringLength(50)] 
        public string UserName { get; set; }

        [StringLength(50)]
        public string WriterSurname { get; set; }

        [StringLength(100)]
        public string WriterTitle { get; set; }

        [StringLength(100)]
        public string AboutWriter { get; set; }
        [StringLength(200)]
        public string WriterMail { get; set; }

        [StringLength(500)]
        public string WriterImage { get; set; }

        //[StringLength(200)]
        //public string WriterTitle { get; set; }

        [StringLength(200)]
        public string WriterPassword { get; set; }

        public bool WriterStatus  { get; set; }

        public ICollection<Heading> Headings { get; set; } //Heading sınıfıyla bağlantı
        public ICollection<Content> Contents { get; set; }
    }
}
