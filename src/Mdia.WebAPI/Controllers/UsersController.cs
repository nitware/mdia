using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Mdia.Model.Model;
using Mdia.Business.Interfaces;
using System.Threading.Tasks;

namespace Mdia.WebAPI.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IRepository _da;
        private readonly IMembershipService _membershipService;

        public UsersController(IRepository da, IMembershipService membershipService)
        {
            if (da == null)
            {
                throw new ArgumentNullException("da");
            }
            if (membershipService == null)
            {
                throw new ArgumentNullException("membershipService");
            }
            
            _da = da;
            _membershipService = membershipService;
        }

        //[NonAction]
        public User GetUser(int id)
        {
            return new Model.Model.User() { Id = Guid.NewGuid() };
        }

        

        public List<User> GetUsers()
        {
            try
            {
                string[] roles = new string[]{ "a", "b" };
                System.Security.Principal.GenericIdentity gi = new System.Security.Principal.GenericIdentity("username");
                System.Security.Principal.GenericPrincipal gp = new System.Security.Principal.GenericPrincipal(gi, roles);
              
                List<User> users = new List<User>()
                {
                    new User() { Id= Guid.NewGuid(), FirstName ="Amanda", Surname="Egoli", Email="egoli@yahoo.com", MobileNumber="08022338876" },
                    new User() { Id= Guid.NewGuid(), FirstName ="Dandi", Surname="Itang", Email="dandi@gmail.com", MobileNumber="08072228876" },
                    new User() { Id= Guid.NewGuid(), FirstName ="Paul", Surname="Atapi", Email="paul@msn.com", MobileNumber="0801111876" },
                    new User() { Id= Guid.NewGuid(), FirstName ="Ulopi", Surname="Sunday", Email="ulopi@nitware.com", MobileNumber="08123098876" },
                };
                
                if (users == null || users.Count <= 0)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }

                return users;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> PostUser(User user)
        {
            try
            {
                return await _membershipService.CreateUserAsync(user);
            }
            catch(Exception)
            {
                throw;
            }
        }





    }
}
