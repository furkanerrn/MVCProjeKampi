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
    public class AdminManager2 : IAdminService2
    {
        IAdminDAL2 _admin2;

        public AdminManager2(IAdminDAL2 admin2)
        {
            _admin2 = admin2;
        }

        public void AdminAddBL(Admin2 admin2)
        {
            _admin2.Insert(admin2);
        }

        public void AdminDeleteBL(Admin2 admin2)
        {
            _admin2.Delete(admin2);
        }

        public void AdminUpdateBL(Admin2 admin2)
        {
            _admin2.Update(admin2);
        }

        public Admin2 GetByID(int id)
        {
            return _admin2.Get(x => x.AdminId == id);
        }

        public List<Admin2> GetList()
        {
            return _admin2.List();
        }
    }
}
