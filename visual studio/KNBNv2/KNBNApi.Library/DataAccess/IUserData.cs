using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public interface IUserData
    {
        void CreateUser(UserModel user);
        void DeleteUser(string Id);
        void UpdateUser(UserModel user);
        void UpdateUserEmail(string Id, string newEmail);
        List<UserModel> GetUserById(string Id);
    }
}
