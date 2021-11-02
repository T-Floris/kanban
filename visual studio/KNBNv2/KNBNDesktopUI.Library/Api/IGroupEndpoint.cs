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

        Task<Dictionary<string, string>> GetAllUsers();

        Task CreateGroup(CreateGroupModel model);
    }
}
