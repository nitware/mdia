using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Business.Interfaces;
using System.Security.Cryptography;

namespace Mdia.Business
{
    public class CryptoService : ICryptoService
    {
        public string GenerateSalt()
        {
            try
            {
                byte[] data = new byte[0x10];
                using (RNGCryptoServiceProvider cryptoServiceProvider = new RNGCryptoServiceProvider())
                {
                    cryptoServiceProvider.GetBytes(data);
                    return Convert.ToBase64String(data);
                }
            }
            catch (Exception)
            {
                throw; 
            }
        }

        public string EncryptPassword(string password, string salt)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                {
                    throw new ArgumentNullException("password");
                }
                if (string.IsNullOrEmpty(salt))
                {
                    throw new ArgumentNullException("salt");
                }
                
                using (SHA256 sha256 = SHA256.Create())
                {
                    string saltedPassword = string.Format("{0}{1}", salt, password);
                    byte[] saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);

                    return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        


    }


}
