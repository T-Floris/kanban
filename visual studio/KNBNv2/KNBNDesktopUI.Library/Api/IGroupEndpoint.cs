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


        Task<List<GroupUserModel>> GetAllUsers(int groupId);
        Task<List<GroupUserModel>> GetAllUsersToAdd(int groupId);

        Task CreateGroup(CreateGroupModel model);
    }
}
