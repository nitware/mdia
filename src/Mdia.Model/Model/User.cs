using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public Role Role { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DateCreated { get; set; }

        public string Name
        {
            get
            {
                return string.Format("{0} {1}", FirstName, Surname);
            }
        }



    }




}
