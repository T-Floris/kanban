using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public interface IUserEndpoint
    {
        Task<List<UserModel>> GetAll();
        Task<Dictionary<string, string>> GetAllRoles();
        Task AddUserToRole(string userId, string roleName);
        Task RemoveUserFromRole(string userId, string roleName);
        Task CreateUser(CreateUserModel model);

        Task DeleteUser(string Id);
        
        Task<UserModel> GetUser();
        
        // Update
        Task UpdateUser(UpdateUserModel model);
        Task UpdateEmail(UpdateEmailModel model);
        Task UpdatePassword(UpdatePasswordModel model);
    }
}