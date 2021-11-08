using KNBNApi.Library.Internal.DataAccess;
using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public class GroupData : IGroupData
    {
        private readonly ISqlDataAccess _sql;

        public GroupData(ISqlDataAccess sql)
        {
            _sql = sql;
        }

        
        public void CreateGroup(GroupModel group)
        {
            _sql.SaveData("dbo.spGroup_Insert", new { group.UserId, group.Name, group.Color }, "KNBNData");
        }

        public void AddUsersToGroup(GroupUserModel groupUser)
        {
            _sql.SaveData("dbo.spGroupUser_Insert", new { groupUser.GroupId, groupUser.UserId }, "KNBNData");
        }

        public void RemoveUsersFromGroup(GroupUserModel groupUser)
        {
            _sql.SaveData("dbo.spGroupUser_Delete", new { groupUser.GroupId, groupUser.UserId }, "KNBNData");
        }

        /*
public Task<Dictionary<string, string>> GetAllUsers()
{
   var output = _sql.LoadData
}
*/
        public List<GroupModel> GetGroups()
        {
            var output = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_GetAll", new { }, "KNBNData");

            return output;
        }
        
        public List<GroupModel> GetGroupTitle(string Name)
        {
            var output = _sql.LoadData<GroupModel, dynamic>("dbo.spGroup_Lookup", new { Name }, "KNBNData");

            return output;
        }

        List<UserModel> IGroupData.GetAllUsersToAdd(int groupId)
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spGroup_UserToAdd", new { groupId }, "KNBNData");

            return output;
        }
        public List<UserModel> GetAllUsers(int groupId, int GetInGroup)
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spGroup_Users", new { groupId, GetInGroup }, "KNBNData");

            return output;
        }


    }
}
