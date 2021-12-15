using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using KNBNApi.Data;
using KNBNApi.Models;
using KNBNApi.Library.DataAccess;
using KNBNApi.Library.Models;

namespace KNBNApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserData _userData;
        private readonly IBoardData _boardData;
        private readonly IGroupData _groupData;
        private readonly ILogger<BoardController> _logger;


        public BoardController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserData userData, ILogger<BoardController> logger, IBoardData boardData, IGroupData groupData)
        {
            _context = context;
            _userManager = userManager;
            _userData = userData;
            _boardData = boardData;
            _logger = logger;
            _groupData = groupData;

        }

        public record CreateBoradModel
        (
            string UserId,
            string Name
            
        );


        #region (Admin+) Create Board

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/CreateBoard")]
        public IActionResult CreateBoard(CreateBoradModel model)
        {
            if (ModelState.IsValid)
            {
                User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return BadRequest();
        }

        #endregion

        [HttpGet]
        [Route("Admin/GetAllBoards")]
        public List<BoardModel> GetAllBoards()
        {
            var boards = _boardData.GetAllBoards();
            return boards;

        }

        [HttpGet]
        [Route("Admin/GetAllUsersBoards")]
        public List<BoardModel> GetAllUsersBoards()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var boards = _boardData.GetAllUsersBoards(userId);
            return boards;

        }

        [Authorize]
        [HttpGet]
        [Route("Admin/GetAllMemberOfBoards")]
        public List<BoardModel> GetAllMemberOfBoards()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            List<BoardModel> boardModels = new List<BoardModel>();

            var groups = _groupData.GetAllGroupUserIsIn(userId);

            foreach (var group in groups)
            {
                var boards = _boardData.GetAllBoardByGroup(group.GroupId);
                foreach (var board in boards)
                {
                    boardModels.Add(new BoardModel() { BoardId = board.BoardId, Color = board.Color, GroupId = board.GroupId, Id = board.Id, Name = board.Name, UserId = board.UserId });
                }

                //boardModels.Add(new BoardModel() { GroupId = group.GroupId, BoardId = group.BoardId });

            }

             
            //var boards = _boardData.GetAllUsersBoards(userId);
            return groups;

        }

    }
}
