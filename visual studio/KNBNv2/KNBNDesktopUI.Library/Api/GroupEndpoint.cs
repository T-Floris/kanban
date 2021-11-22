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
        //create group
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

        //Get all groups
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

        /*
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
        */

        #region get all users in and not in selected group

        public async Task<List<UserModel>> GetAllUsersInGroup(int groupId)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GetAllUsers/" + groupId + "/1"))
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

        public async Task<List<UserModel>> GetAllUsersNotInGroup(int groupId)
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GetAllUsers/" + groupId + "/0"))
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

        #endregion

        #region Search functions

        public async Task<List<UserModel>> UserInGroupLookup(int groupId, string username)
        {
            if (username == "")
            {
                username = "%";
            }
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/SearchUserInGroup/" + groupId + "/" + username))
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

        public async Task<List<UserModel>> UserNotInGroupLookup(int groupId, string username)
        {
            if (username == "")
            {
                username = "%";
            }
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/SearchUser/" + groupId + "/" + username))
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

        public async Task<List<GroupModel>> GroupLookup(string groupName)
        {  
            if (groupName == "")
            {
                groupName = "%";
            }
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/SearchGroup/" + groupName))
            {
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
        }
        
        #endregion

        #region add and remove user from group

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


        #endregion
        public async Task<List<GroupPermisionModel>> GetAllPermissions()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GroupPermissions");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<GroupPermisionModel>>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<string> GetUsersPermission()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Group/Admin/GroupPermissions");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<string>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
