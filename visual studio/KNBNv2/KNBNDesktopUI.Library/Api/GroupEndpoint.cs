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
    }
}
