using KNBNApi.Library.Internal.DataAccess;
using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        public List<UserModel> GetUserById(string Id)
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spUser_Lookup", new { Id }, "KNBNData");

            return output;
        }

        public void CreateUser(UserModel user)
        {
            _sql.SaveData("dbo.spUser_Insert", new { user.Id, user.FirstName, user.LastName, user.EmailAddress, user.UserName }, "KNBNData");
        }

        public void DeleteUser(string Id)
        {
            _sql.LoadData<UserModel, dynamic>("dbo.spUser_Delete", new { Id }, "KNBNData");

        }

        public void UpdateUser(UserModel user)
        {
            _sql.UpdateData("dbo.spUser_Update", new { user.Id, user.FirstName, user.LastName, user.EmailAddress, user.UserName }, "KNBNData");
        }

        public void UpdateUserEmail(string Id, string newEmail)
        {
            _sql.UpdateUserEmail("dbo.spUserEmail_Update", new { Id, newEmail }, "KNBNData");
        }
    }
}