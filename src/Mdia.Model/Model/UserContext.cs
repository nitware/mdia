using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Principal;

namespace Mdia.Model.Model
{
    public class UserContext
    {
        public User User { get; set; }
        public IPrincipal Principal { get; set; }
    }


}
