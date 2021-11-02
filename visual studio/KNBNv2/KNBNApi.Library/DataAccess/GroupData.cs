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

        List<UserModel> IGroupData.GetAllUsers()
        {
            var output = _sql.LoadData<UserModel, dynamic>("dbo.spGroup", new { }, "KNBNData");

            return output;
        }
    }
}
