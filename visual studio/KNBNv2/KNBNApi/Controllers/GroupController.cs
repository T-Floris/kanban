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
    public class GroupController : ControllerBase
    {
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        private readonly ILogger<UserController> _logger;

        private readonly IUserData _userData;
        
        private readonly IGroupData _groupData;
<<<<<<< HEAD

        public GroupController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<UserController> logger, IUserData userData, IGroupData groupData)
=======
        /*
        private readonly ILogger<UserController> _logger;
        */
        public GroupController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserData userData, ILogger<UserController> logger, IGroupData groupData)
>>>>>>> til_m
        {
            
            _context = context;
            _userManager = userManager;
<<<<<<< HEAD

            _logger = logger;

            _userData = userData;
            _groupData = groupData;
        }

        #region (Admin and above role) Create Group whit the logt in user as owner
=======
            _userData = userData;
            //_logger = logger;
            
            _groupData = groupData;
        }
        
        #region (Admin+) Create Group whit the logt in user as owner
>>>>>>> til_m
        public record CreateGroupModel
        (
            string Name,
            string Color
        );

<<<<<<< HEAD
        [Authorize(Roles = "Admin,Super Admin")]
        [HttpPost]
        [Route("CreateGroup")]
        public void CreateGroup(CreateGroupModel model)
=======
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/CreateGroup")]
        public IActionResult CreateGroup(CreateGroupModel model)
>>>>>>> til_m
        {
            if (ModelState.IsValid)
            {
                User.FindFirstValue(ClaimTypes.NameIdentifier);
<<<<<<< HEAD

                var existingGroup = _groupData.GetGroupTitle(model.Name);

                if (existingGroup is null)
                {
                    string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var u = _userData.GetUserById(loggedInUserId);

                    GroupModel group = new()
                    {
                        UserId = model.UserId,
                        Name = model.Name,
                        Color = model.Color
                    };

                    _groupData.CreateGroup(group);
                }
            }
        }
        #endregion

        #region (Admin and above role)


        #endregion
=======

                //var existingGroup = _groupData.GetGroupTitle(model.Name);

                if (true)
                {
                    string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    var u = _userData.GetUserById(loggedInUserId);
                    
                    GroupModel group = new()
                    {
                        UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                        Name = model.Name,
                        Color = model.Color
                    };
                    

                    _groupData.CreateGroup(group);
                    return Ok();
                }
            }

            return BadRequest();
        }
        #endregion
 

        #region (Admin+) Get all groups
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllGroups")]
        public List<GroupModel> GetAllGroups()
        {
            var groups = _groupData.GetGroups();
            return groups;

        }

        #endregion


        #region Controle members of group
        public record ControleGroupUserModel
        (
            int groupId,
            string userId
        );

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/AddUsersToGroup")]
        public IActionResult AddUsersToGroup(ControleGroupUserModel groupUser)
        {

            if (ModelState.IsValid)
            {
                GroupUserModel gu = new()
                {
                    GroupId = groupUser.groupId,
                    UserId = groupUser.userId
                };

                _groupData.AddUsersToGroup(gu);
            }
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Admin/RemoveUsersFromGroup/{groupId}/{userId}")]
        public IActionResult RemoveUserFromGroup(int groupId, string userId)
        {
            if (ModelState.IsValid)
            {
                
                GroupUserModel gu = new()
                {
                    GroupId = groupId,
                    UserId = userId
                };
                

               _groupData.RemoveUsersFromGroup(gu);
            }
            return Ok();


        }

        #endregion
        #region (Admin+) Get all users

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllUsers/{groupId}/{GetInGroup}")]
        public List<UserModel> GetAllUsers(int groupId, int GetInGroup)
        {
            var users = _groupData.GetAllUsers(groupId, GetInGroup);
            return users;
        }


        #endregion

        #region Search user in group
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/SearchUserInGroup/{groupId}/{username}")]
        public List<UserModel> SearchUserInGroup(int groupId, string username)
        {
            var users = _groupData.SearchUserInGroup(groupId, username);
           return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/SearchUser/{groupId}/{username}")]
        public List<UserModel> SearchUserNotInGroup(int groupId, string username)
        {
            var users = _groupData.SearchUserNotInGroup(groupId, username);
            return users;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/SearchGroup/{groupName}")]
        public List<GroupModel> SearchGroup(string groupName)
        {
            var users = _groupData.SearchGroup(groupName);
            return users;
        }
        #endregion

>>>>>>> til_m
    }
}
