using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Data;
using ServicesProvider.Data.DbObjects;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.ViewModels;

namespace ServicesProvider.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private DbUsersAdManager _dbUsersAdManager;
        public ItemController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _dbUsersAdManager = new(applicationDbContext, userManager);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UsersAdViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid data");
                return View(model);
            }

            var user = GetCurrentUser();
            _dbUsersAdManager.AddUserAd(model, user);

            return View();
        }

        private ApplicationUser GetCurrentUser()
        {  
            ClaimsPrincipal currentUser = this.User;
            var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userManager.FindByIdAsync(currentUserName).GetAwaiter()
                .GetResult();
        }
    }
}
