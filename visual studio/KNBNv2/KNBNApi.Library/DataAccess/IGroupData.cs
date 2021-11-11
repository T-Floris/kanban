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

<<<<<<< HEAD
        List<GroupUserModel> GetGroupTitle(string Name);
=======
        List<GroupModel> GetGroups();

        List<UserModel> GetAllUsersToAdd(int groupId);

        List<UserModel> GetAllUsers(int groupId, int GetInGroup);

        #region Search functions
        List<UserModel> SearchUserInGroup(int groupId, string username);
        List<UserModel> SearchUserNotInGroup(int groupId, string username);
        List<GroupModel> SearchGroup(string groupName);

        #endregion

        #region add and remove user from group
        void AddUsersToGroup(GroupUserModel groupUser);

        void RemoveUsersFromGroup(GroupUserModel groupUser);
        #endregion


        List<GroupModel> GetGroupTitle(string Name);
>>>>>>> til_m
    }
}
