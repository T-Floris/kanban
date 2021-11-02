using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public interface IGroupData
    {
        void CreateGroup(GroupModel user);

        List<GroupModel> GetGroups();

        List<UserModel> GetAllUsers();
        List<GroupModel> GetGroupTitle(string Name);
    }
}
