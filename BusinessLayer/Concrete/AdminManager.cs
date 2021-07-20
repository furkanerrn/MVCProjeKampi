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
    public class AdminManager : IAdminService
    {
        IAdminDAL _admin;
        public AdminManager(IAdminDAL admin)
        {
            _admin = admin;
        }

        public void AdminAddBL(Admin admin)
        {
            _admin.Insert(admin);
        }

        public void AdminDeleteBL(Admin admin)
        {
            _admin.Delete(admin);
        }

        public void AdminUpdateBL(Admin admin)
        {
            _admin.Update(admin);
        }

        public Admin GetByID(int id)
        {
            return _admin.Get(x => x.AdminID == id);
        }

        public List<Admin> GetList()
        {
           return _admin.List();
        }
    }
}
