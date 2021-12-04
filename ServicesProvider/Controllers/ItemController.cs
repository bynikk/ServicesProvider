using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Data;
using ServicesProvider.Data.DbObjects;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.ViewModels;
using ServicesProvider.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using ServicesProvider.Service;
using Microsoft.AspNetCore.Hosting;

namespace ServicesProvider.Controllers
{
    public class ItemController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private DbUsersAdManager _dbUsersAdManager;
        private ValidatorViewModel _validator = new();

        private IUsersAdsCategory _usersAdsCategory;

        private List<SelectListItem> _selectList;

        public ItemController(
            ApplicationDbContext applicationDbContext,
            UserManager<ApplicationUser> userManager,
            IUsersAdsCategory usersAdsCategory,
            IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _dbUsersAdManager = new(applicationDbContext, hostEnvironment);
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
                ViewBag.SelectList = _usersAdsCategory.UbdateSelectList(_selectList);
                return View(model);
            }

            if (!_validator.ValidateUsersAdViewModel(model))
            {
                ViewBag.SelectList = _usersAdsCategory.UbdateSelectList(_selectList);
                ModelState.AddModelError("", "Server Error");
                return View(model);
            }

            var user = GetCurrentUser();
            var result = _dbUsersAdManager.AddUserAd(model, user);
            if (!result)
            {
                ViewBag.SelectList = _usersAdsCategory.UbdateSelectList(_selectList);
                ModelState.AddModelError("", "Server Error");
                return View();
            }

            return Redirect("/Home/Index/");
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
