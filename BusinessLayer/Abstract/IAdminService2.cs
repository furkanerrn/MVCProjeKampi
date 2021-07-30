using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService2
    {
        List<Admin2> GetList();
        void AdminAddBL(Admin2 admin2);
        void AdminDeleteBL(Admin2 admin2);
        void AdminUpdateBL(Admin2 admin2);
        Admin2 GetByID(int id);
    }
}
