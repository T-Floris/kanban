using KNBNApi.Library.Internal.DataAccess;
using KNBNApi.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNBNApi.Library.DataAccess
{
    public class BoardData : IBoardData
    {
        private readonly ISqlDataAccess _sql;

        public BoardData(ISqlDataAccess sql)
        {
            _sql = sql;
        }


        #region Post
        public void BoardCreate(BoardModel board)
        {
            _sql.SaveData("dbo.spBoard_Insert", new { board.UserId, board.Name }, "KNBNData");
        }
        #endregion

        #region Delete
        public void BoardDelete(BoardModel board)
        {
            _sql.SaveData("dbo.spBoard_Delete", new { }, "KNBNData");
        }
        #endregion

        #region Update
        public void BoardUpdate(BoardModel board)
        {
            _sql.SaveData("dbo.spBoard_Update", new { board.Id, board.UserId, board.Name }, "KNBNData");
        }


        #endregion

        #region GET
        public List<BoardModel> GetAllBoards()
        {
            var output = _sql.LoadData<BoardModel, dynamic>("dbo.spBoard_GetAll", new { }, "KNBNData");

            return output;
        }

        public List<BoardModel> GetAllUsersBoards(string userId)
        {
            var output = _sql.LoadData<BoardModel, dynamic>("dbo.spBoard_GetAllUsers", new { userId }, "KNBNData");

            return output;
        }

        public List<BoardModel> GetBoardById(int id)
        {
            var output = _sql.LoadData<BoardModel, dynamic>("dbo.spBoard_GetByID", new { id }, "KNBNData");

            return output;

        }

        public List<BoardModel> GetAllBoardByGroup(int groupId)
        {
            var output = _sql.LoadData<BoardModel, dynamic>("dbo.spBoard_ByGroupId", new { groupId }, "KNBNData");

            return output;
        }
        #endregion
    }
}
