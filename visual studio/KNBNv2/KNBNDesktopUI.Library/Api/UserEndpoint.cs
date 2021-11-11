using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public class UserEndpoint : IUserEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public UserEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<UserModel>> GetAll()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/User/Admin/GetAllUsers"))
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

        public async Task<Dictionary<string, string>> GetAllRoles()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/User/Admin/GetAllRoles"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<Dictionary<string, string>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task AddUserToRole(string userId, string roleName)
        {
            var data = new { userId, roleName };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/User/Admin/AddRole", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task RemoveUserFromRole(string userId, string roleName)
        {
            var data = new { userId, roleName };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/User/Admin/RemoveRole", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task CreateUser(CreateUserModel model)
        {
            var data = new
            {
                model.FirstName,
                model.LastName,
                model.EmailAddress,
                model.Password,
                model.UserName
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("api/User/Register", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<UserModel> GetUser()
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/User"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<UserModel>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }

        }

        public async Task UpdateUser(UpdateUserModel model)
        {
            var date = new
            {
                model.Id,
                model.FirstName,
                model.LastName,
                model.EmailAddress,
                model.Password,
                model.UserName
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("api/User/Update", date))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task UpdateEmail(UpdateEmailModel model)
        {
            var data = new
            {
                model.CurrentEmail,
                model.NewEmail,
                model.Token
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("api/User/UpdateEmail", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task UpdatePassword(UpdatePasswordModel model)
        {
            var data = new
            {
                model.currentPassword,
                model.NewPassword,
                model.PasswordRepeat
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("api/User/UpdatePassword", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task DeleteUser(string UserId)
        {
            var data = new
            {
                UserId
            };

            using (HttpResponseMessage response = await _apiHelper.ApiClient.PutAsJsonAsync("api/User/DeleteUser", data))
            {
                if (response.IsSuccessStatusCode == false)
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}