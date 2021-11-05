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
        Task<List<GroupModel>> GetAll();


        Task<List<UserModel>> GetAllUsers(int groupId, int GetInGroup);
        Task<List<GroupUserModel>> AddUserToGroup(int groupId, string userId);

        Task CreateGroup(CreateGroupModel model);
    }
}
