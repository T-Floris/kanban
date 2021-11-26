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

        public void CreateGroup(BoardModel board)
        {
            _sql.SaveData("dbo.spBoard_Insert", new { board.UserId, board.Name }, "KNBNData");
        }
    }
}
