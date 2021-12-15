using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public interface IBoardData
    {
        // Create Board


        #region GET commands
        #region GET Board
        List<BoardModel> GetAllBoards();
        List<BoardModel> GetBoardById(int id);
        List<BoardModel> GetBoardsUserIsNotOwnerOf(string userId);
        #endregion

        #region GET All Boards by owner
        List<BoardModel> GetAllUsersBoards(string userId);


        #endregion

        #region GET All Board By Group is member of
        List<BoardModel> GetAllBoardByGroup(int groupId);

        #endregion

        #endregion


        #region POST commands
        void BoardCreate(BoardModel board);


        #endregion


        #region PUT commands
        void BoardUpdate(BoardModel board);

        #endregion


        #region DELETE commands
        void BoardDelete(BoardModel board);
        #endregion
        /*

        #region Get boards and selected board
        
        // get a list of all the boads in the database
        List<BoardModel> GetAllBoards();

        // get the selected board from the database
        BoardModel GetBoard(int id);

        #endregion


        #region Add and remove group from board

        // Add Group to board 
        void AddGroupToBoard();

        // remove group from board
        void RemoveGroupFromBoard();

        #endregion
        */
    }
}
