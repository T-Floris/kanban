using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public interface IGroupEndpoint
    {
        Task CreateGroup(CreateGroupModel model);

        Task<List<GroupModel>> GetAll();



        #region get all users in and not in selected group

        // Task<List<UserModel>> GetAllUsers(int groupId, int GetInGroup);
        Task<List<UserModel>> GetAllUsersInGroup(int groupId);
        Task<List<UserModel>> GetAllUsersNotInGroup(int groupId);

        #endregion

        #region add and remove user from group

        Task RemoveUserFromGroup(int groupId, string userId);
        Task<List<GroupUserModel>> AddUserToGroup(int groupId, string userId);

        #endregion

        #region Search functions

        Task<List<UserModel>> UserNotInGroupLookup(int groupId, string username);
        Task<List<UserModel>> UserInGroupLookup(int groupId, string username);
        Task<List<GroupModel>> GroupLookup(string groupName);

        #endregion

        // group permission

        Task<List<GroupPermisionModel>> GetAllPermissions();

        Task<List<GroupUserPermissionModel>> GetUsersPermission(int groupId, string userId);
    }
}
