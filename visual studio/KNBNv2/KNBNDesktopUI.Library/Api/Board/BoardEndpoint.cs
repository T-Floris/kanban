using KNBNDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KNBNDesktopUI.Library.Api
{
    public class BoardEndpoint : IBoardEndpoint
    {
        private readonly IAPIHelper _apiHelper;

        public BoardEndpoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }


        public Task DeleteBoard(string userId, int boardId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BoardModel>> GetAll()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Board/Admin/GetAllBoards");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<BoardModel>>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public async Task<List<BoardModel>> GetBoards(/*string userId*/)
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Board/Admin/GetAllUsersBoards");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<BoardModel>>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
        public async Task<List<BoardModel>> GetBoardsMemberOf()
        {
            using HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Board/Admin/GetAllMemberOfBoards");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<List<BoardModel>>();
                return result;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }

        public Task<List<BoardModel>> GetBoards(BoardCreateModel model)
        {
            throw new NotImplementedException();
        }


        public Task<BoardCreateModel> PostBoard(BoardCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task RemoveUserFromBoard(string userId, int boardId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBoard(BoardUpdateModel model)
        {
            throw new NotImplementedException();
        }
    }
}
