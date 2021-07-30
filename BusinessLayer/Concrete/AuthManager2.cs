using BusinessLayer.Abstract;
using BusinessLayer.Utilities.Security.Hashing;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager2 : IAuthService2
    {
        IAdminService2 _adminService2;

        public AuthManager2(IAdminService2 adminService2)
        {
            _adminService2 = adminService2;
        }

        public bool AdminLogin2(AdminDto admindto)
        {
            using (var crypto = new System.Security.Cryptography.HMACSHA512())
            {
                byte[] username = crypto.ComputeHash(Encoding.UTF8.GetBytes(admindto.UserName));
                var admin = _adminService2.GetList();
                foreach (var item in admin)
                {
                    if (HashingHelper.VerifyPasswordHash(admindto.Password,admindto.UserName,
                        item.AdminPasswordHash,item.AdminUserName, item.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister2(string username, string password, string adminRole)
        {
            byte[] usernameHash, passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, username, out passwordHash, out usernameHash, out passwordSalt);
            var admin = new Admin2
            {
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminRole = adminRole,
                AdminUserName = usernameHash

            };
            _adminService2.AdminAddBL(admin);
        }
    }
}
