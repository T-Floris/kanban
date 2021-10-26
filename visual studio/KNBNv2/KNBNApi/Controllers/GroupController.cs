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

        public GroupController(ApplicationDbContext context, UserManager<IdentityUser> userManager, ILogger<UserController> logger, IUserData userData, IGroupData groupData)
        {
            _context = context;
            _userManager = userManager;

            _logger = logger;

            _userData = userData;
            _groupData = groupData;
        }

        #region (Admin and above role) Create Group whit the logt in user as owner
        public record CreateGroupModel
        (
            string UserId,
            string Name,
            string Color
        );

        [Authorize(Roles = "Admin,Super Admin")]
        [HttpPost]
        [Route("CreateGroup")]
        public void CreateGroup(CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {
                User.FindFirstValue(ClaimTypes.NameIdentifier);

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
    }
}
