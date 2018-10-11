using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Model.Model;

namespace Mdia.Business.Interfaces
{
    public interface IMembershipService
    {
        Task<User> CreateUserAsync(User user);
                
        Task<User> GetUserByAsync(Guid id);
        Task<List<User>> GetAllUsersAsync();
        Task<User> GetUserByAsync(string email);
        
        bool ChangePassword(string username, string oldPassword, string newPassword);
        Task<UserContext> ValidateUserAsync(string username, string password);
        Task<bool> UserExistAsync(string email);



    }




}
