﻿using KNBNApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KNBNApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager
            , UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            /**
 * This is used to initialized our db with roles and assign a user with whatever roles created
 */

            /*
            string[] roles = { "Super Admin", "Admin", "User" };

            foreach (var role in roles)
            {
                var roleExist = await _roleManager.RoleExistsAsync(role);

                if (roleExist == false)
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var user = await _userManager.FindByEmailAsync("tino@mail.dk");

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            */

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
