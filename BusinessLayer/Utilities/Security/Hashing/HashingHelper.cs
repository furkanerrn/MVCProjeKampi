using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        public static void CreatePasswordHash(string password,string username, out byte[] passwordHash,out byte[] usernameHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                usernameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
            }
        }
        public static bool VerifyPasswordHash(string password,string username,byte[] passwordHash,byte[] usernameHash,byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedpasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
               
                for (int i = 0; i < computedpasswordHash.Length; i++)
                {
                    if (computedpasswordHash[i]!=passwordHash[i])   
                    {
                        return false;
                    }
                   
                }

                var computedusernameHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(username));
                for (int i = 0; i < computedusernameHash.Length; i++)
                {
                    if (computedusernameHash[i]!=usernameHash[i])
                    {
                        return false;
                    }
                }
            }
                 return true;
        }

    }
}
