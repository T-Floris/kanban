using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNBNDesktopUI.Library.Models;

namespace KNBNDesktopUI.Library.Api
{
    public interface  IBoardEndpoint
    {
        // Create Board
        //Task CreateBoard(BoardCreateModel model);


        //Get Comand
        #region GET
        Task<List<BoardModel>> GetAll();
        Task<List<BoardModel>> GetBoards(/*string userId*/);

        Task<List<BoardModel>> GetBoardsMemberOf();
        //Task<List<BoardModel>> GetBoards(BoardCreateModel model);

        #endregion

        #region POST
        Task<BoardCreateModel> PostBoard(BoardCreateModel model);

        #endregion

        #region PUT
        Task UpdateBoard(BoardUpdateModel model);

        #endregion

        #region DELETE
        Task DeleteBoard(string userId, int boardId);

        Task RemoveUserFromBoard(string userId, int boardId);

        #endregion

        // Delete Board

        // members od board

        




    }
}
