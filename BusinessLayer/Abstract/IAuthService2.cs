using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService2
    {
        bool AdminLogin2(AdminDto admindto);
        void AdminRegister2(string username, string password, string adminRole);
    }
}
