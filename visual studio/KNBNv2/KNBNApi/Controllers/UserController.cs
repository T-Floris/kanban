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
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserData _userData;
        private readonly ILogger<UserController> _logger;


        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager, IUserData userData, ILogger<UserController> logger)
        {
            _context = context;
            _userManager = userManager;
            _userData = userData;
            _logger = logger;
        }

        #region find the logt in user by Id
        [HttpGet]
        public UserModel GetById()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //old way - RequestContext.Principal.Identity.GetUserId();

            return _userData.GetUserById(userId).First();

        }
        #endregion

        #region (Admin) controle the usere role

        [Authorize]
        [HttpGet]
        [Route("Admin/GetAllUsers")]
        public List<ApplicationUserModel> GetAllUsers()
        {
            List<ApplicationUserModel> output = new List<ApplicationUserModel>();

            var users = _context.Users.ToList();

            var userRoles = from ur in _context.UserRoles
                            join r in _context.Roles on ur.RoleId equals r.Id
                            select new { ur.UserId, ur.RoleId, r.Name };

            foreach (var user in users)
            {
                ApplicationUserModel u = new ApplicationUserModel
                {
                    Id = user.Id,
                    Email = user.Email
                };

                u.Roles = userRoles.Where(x => x.UserId == u.Id).ToDictionary(key => key.RoleId, val => val.Name);

                //foreach (var r in user.Roles)
                //{
                //    u.Roles.Add(r.RoleId, roles.Where(x => x.Id == r.RoleId).First().Name);
                //}

                output.Add(u);
            }

            return output;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllRoles")]
        public Dictionary<string, string> GetAllRoles()
        {
            var roles = _context.Roles.ToDictionary(x => x.Id, x => x.Name);
            return roles;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/AddRole")]
        public async Task AddARole(UserRolePairModel pairing)
        {
            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(pairing.UserId);

            _logger.LogInformation("Admin {Admin} added user {User} to role {Role}",
                loggedInUserId, user.Id, pairing.RoleName);

            await _userManager.AddToRoleAsync(user, pairing.RoleName);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("Admin/RemoveRole")]
        public async Task RemoveARole(UserRolePairModel pairing)
        {
            var user = await _userManager.FindByIdAsync(pairing.UserId);

            string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger.LogInformation("Admin {Admin} removed user {User} from role {Role}",
                loggedInUserId, user.Id, pairing.RoleName);

            await _userManager.RemoveFromRoleAsync(user, pairing.RoleName);
        }

        #endregion

        #region (Anonymous) create user, and set role to "user"

        public record UserRegistrationModel(
            string FirstName,
            string LastName,
            string EmailAddress,
            string Password,
            string UserName
        );

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserRegistrationModel user)
        {
            if (ModelState.IsValid)
            {
                
                var existingUser = await _userManager.FindByEmailAsync(user.EmailAddress);
                if (existingUser is null)
                {
                    IdentityUser newUser = new()
                    {
                        Email = user.EmailAddress,
                        EmailConfirmed = true,
                        UserName = user.EmailAddress
                    };

                    IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                    if (result.Succeeded)
                    {
                        existingUser = await _userManager.FindByEmailAsync(user.EmailAddress);

                        if (existingUser is null)
                        {
                            return BadRequest();
                        }

                        UserModel u = new()
                        {
                            Id = existingUser.Id,
                            FirstName = user.FirstName,
                            LastName = user.LastName,
                            EmailAddress = user.EmailAddress,
                            UserName = user.UserName,
                            CreatedDate = DateTime.Now
                        };

                        _userData.CreateUser(u);
                        await _userManager.AddToRoleAsync(existingUser, "User");
                        return Ok();
                    }
                }
            }

            return BadRequest();
        }

        #endregion

<<<<<<< HEAD
        #region (Authorize) change user info for yourself
        //TODO UpdateUserInfo
=======
        #region (Authorize) change user info
        //UpdateUserInfo
>>>>>>> til_m
        public record UpdateUserInfoModel(
            string currentPassword,
            string newPassword
        );

        [Authorize]
        [HttpPut]
        [Route("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo(UpdateUserInfoModel model)
        {
            if (ModelState.IsValid)
            {
                string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                IdentityUser result = await _userManager.FindByIdAsync(loggedInUserId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        public record UpdateEmailModel(
            string currentEmail,
            string NewEmail
        );

        [Authorize]
        [HttpPut]
        [Route("UpdateEmail")]
        public async Task<IActionResult> UpdateEmail(UpdateEmailModel model)
        {
            if (ModelState.IsValid)
            {
                string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // git the user
                IdentityUser result = await _userManager.FindByEmailAsync(model.currentEmail);

                // generate token on email
                var token = await _userManager.GenerateChangeEmailTokenAsync(result, model.NewEmail);

                // update email (This is used to login)
                await _userManager.ChangeEmailAsync(result, model.NewEmail, token);
                await _userManager.SetUserNameAsync(result, model.NewEmail);

                // Update user info
                var t = _userData.GetUserById(loggedInUserId);
                _userData.UpdateUserEmail(loggedInUserId, model.NewEmail);

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        public record UpdatePasswordModel(        
            string currentPassword, 
            string newPassword
        );

        [Authorize]
        [HttpPut]
        [Route("UpdatePassword")]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                IdentityUser result = await _userManager.FindByIdAsync(loggedInUserId);

                if (await _userManager.CheckPasswordAsync(result, model.currentPassword))
                {
                    await _userManager.ChangePasswordAsync(result, model.currentPassword, model.newPassword);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

            }

            return BadRequest();
        }

        #endregion

        #region (Authorize) Delet user (delete the user you're logt in as) 
        [Authorize]
        [HttpDelete]
        [Route("DeleteUser")]
        public async Task DeleteUser()
<<<<<<< HEAD
=======
        {
            var user = await _userManager.FindByIdAsync(ClaimTypes.NameIdentifier);

            await _userManager.DeleteAsync(user);
            _userData.DeleteUser(user.Id);
        }

        #endregion

        #region (Admin) Delete selected user
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("Admin/DeleteUser")]
        public async Task DeleteSelectedUser(DeleteUserModel model)
>>>>>>> til_m
        {
            if (ModelState.IsValid)
            {
                //var user = await _userManager.FindByIdAsync(model.UserId);
                IdentityUser user = await _userManager.FindByIdAsync(ClaimTypes.NameIdentifier);

<<<<<<< HEAD
                //string loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
               /* _logger.LogInformation("Admin {Admin} Deletet user {User}",
                    loggedInUserId, user.Id);
               */
               
                await _userManager.DeleteAsync(user);
                _userData.DeleteUser(user.Id);
            }
        }

        #endregion

        #region (Admin) Delet slected user
        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("Admin/GetAllUsers")]
        public async Task DeleteSelectedUser(DeleteUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.UserId);

=======
>>>>>>> til_m
                await _userManager.DeleteAsync(user);
                _userData.DeleteUser(user.Id);
            }
        }


        #endregion

    }
}

