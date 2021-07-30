using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace EntityLayer.Concrete
{
   public class Admin
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(150)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string AdminPassword { get; set; }
        [StringLength(150)]
        public string AdminRole { get; set; }

        public byte[] AdminPasswordHash { get; set; }
        public byte[] AdminPasswordSalt { get; set; }

    }
}
