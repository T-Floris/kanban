﻿using System;
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
        private readonly IUserData _userData;
        private readonly IGroupData _groupData;
        private readonly ILogger<UserController> _logger;

        public GroupController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserData userData, ILogger<UserController> logger, IGroupData groupData)
        {
            _context = context;
            _userManager = userManager;
            _userData = userData;
            _logger = logger;
            _groupData = groupData;
        }

        public record CreateGroupModel
        (
            string UserId,
            string Name,
            string Color
        );

        [AllowAnonymous]
        [HttpPost]
        [Route("CreateGroup")]
        public async Task<IActionResult> CreateGroup(CreateGroupModel model)
        {
            if (ModelState.IsValid)
            {
                string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var u = _userData.GetUserById(loggedInUserId);

                GroupModel g = new()
                {
                    UserId = model.UserId,
                    Name = model.Name,
                    Color = model.Color
                };

                _groupData.CreateGroup(g);

                return Ok();
            }

            return BadRequest();
        }
    }
}
