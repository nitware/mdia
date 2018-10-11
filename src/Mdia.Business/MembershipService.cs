using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Business.Interfaces;
using Mdia.Model.Model;
using Mdia.Entity;
using System.Security.Principal;

namespace Mdia.Business
{
    public class MembershipService : IMembershipService
    {
        private readonly IRepository _da;
        private readonly ICryptoService _cryptoService;

        public MembershipService(IRepository da, ICryptoService cryptoService)
        {
            if (da == null)
            {
                throw new ArgumentNullException("da");
            }
            if (cryptoService == null)
            {
                throw new ArgumentNullException("cryptoService");
            }

            _da = da;
            _cryptoService = cryptoService;
        }

        public async Task<User> GetUserByAsync(Guid id)
        {
            try
            {
                return await _da.GetModelByAsync<User, USER>(u => u.User_Id == id);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            try
            {
                return await _da.GetAllAsync<User, USER>();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<User> GetUserByAsync(string email)
        {
            try
            {
                return await _da.GetModelByAsync<User, USER>(u => u.Email == email);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<User> CreateUserAsync(User user)
        {
            try
            {
                if (user == null)
                {
                    throw new ArgumentNullException("user");
                }

                if (await UserExistAsync(user.Email))
                {
                    throw new Exception("User already exist!");
                }

                user.Id = Guid.NewGuid();
                user.PasswordSalt = _cryptoService.GenerateSalt();
                user.Password = _cryptoService.EncryptPassword(user.Password, user.PasswordSalt);
                user.Role = new Role() { Id = 2 }; //default role
                user.DateCreated = DateTime.Now;
                user.IsLocked = false;

                //User newUser = _da.Create(user);

                User newUser = await _da.CreateAsync(user);
                if (newUser == null)
                {
                    throw new Exception("User creation operation failed! Please try again.");
                }

                //send email

                return user;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<bool> UserExistAsync(string email)
        {
            try
            {
                User user = await _da.GetModelByAsync<User, USER>(u => u.Email == email);

                return user != null ? true : false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<UserContext> ValidateUserAsync(string username, string password)
        {
            try
            {
                UserContext userContext = null;
                User user = await _da.GetModelByAsync<User, USER>(u => u.Email == username);

                if (user != null && IsUserValid(user, password))
                {
                    userContext = new UserContext();
                    string[] roles = new string[] { user.Role.Name };
                    GenericIdentity identity = new GenericIdentity(user.Name);

                    userContext.User = user;
                    userContext.Principal = new GenericPrincipal(identity, roles);
                }

                return userContext;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        private bool IsUserValid(User existingUser, string password)
        {
            try
            {
                if (existingUser == null)
                {
                    throw new ArgumentNullException("existingUser");
                }

                if (IsPasswordValid(existingUser, password))
                {
                    return !existingUser.IsLocked;
                }

                return false;
            }
            catch(Exception)
            {
                throw;
            }
        }

        private bool IsPasswordValid(User existingUser, string password)
        {
            try
            {
                if (existingUser == null)
                {
                    throw new ArgumentNullException("existingUser");
                }

                string enteredPassword = _cryptoService.EncryptPassword(password, existingUser.PasswordSalt);
                return string.Equals(enteredPassword, existingUser.Password);
            }
            catch(Exception)
            {
                throw;
            }
        }



    }


}
