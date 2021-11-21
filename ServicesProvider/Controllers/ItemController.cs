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
using ServicesProvider.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServicesProvider.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private DbUsersAdManager _dbUsersAdManager;

        private IUsersAdsCategory _usersAdsCategory;

        private List<SelectListItem> _selectList;

        public ItemController(ApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager,
            IUsersAdsCategory usersAdsCategory)
        {
            _userManager = userManager;
            _dbUsersAdManager = new(applicationDbContext, userManager);
            _usersAdsCategory = usersAdsCategory;
            _selectList = _usersAdsCategory.GetSelectListItems;
        }

        [HttpGet]
        public IActionResult Add()
        {
            //var selectList = new SelectList(_usersAdsCategory.AllCategories, nameof(Category.Id), nameof(Category.CategoryName));
            ViewBag.SelectList = _usersAdsCategory.UbdateSelectList(_selectList);
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
