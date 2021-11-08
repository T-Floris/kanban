using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public class GroupEndpoint : IGroupEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public GroupEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task CreateGroup(CreateGroupModel model)
        {
            var data = new
            {
                model.Name,
                model.Color
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/Group/Admin/CreateGroup", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<GroupModel>> GetAll()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GetAllGroups");            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<GroupModel>>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
            
        }

        public async Task<List<GroupUserModel>> AddUserToGroup(int groupId, string userId)
        {
            var date = new
            {
                groupId,
                userId
            };
            
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Group/Admin/AddUsersToGroup/", date))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<GroupUserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<List<UserModel>> GetAllUsers(int groupId, int GetInGroup)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GetAllUsers/" + groupId + "/" + GetInGroup))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<UserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        /*
        public async Task AddUserToGroup(string userId, int groupId)
        {
            var data = new { userId, groupId };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/Group/Admin/AddUser", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        */
        /*
        public async Task RemoveUserFromGroup(string userId, int groupId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync("/api/Group/Admin/RemoveUsersFromGroup/" + userId + "/" + groupId))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        */
        public async Task RemoveUserFromGroup(int groupId, string userId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.DeleteAsync("/api/Group/Admin/RemoveUsersFromGroup/" + groupId + "/" + userId))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }


            }

        }

        /*
        public async Task<List<GroupUserModel>> GetAllUsersToAdd(int groupId)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GetAllUsers/" + groupId))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<GroupUserModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        */
    }
}
