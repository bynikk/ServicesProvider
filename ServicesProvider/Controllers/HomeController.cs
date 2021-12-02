﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServicesProvider.Models;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.Interfaces;

namespace ServicesProvider.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IAllUsersAds _allUsersAds;
        private readonly IUsersAdsCategory _usersAdsCategory;

        private List<SelectListItem> _selectList;


        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IAllUsersAds allUsersAds,
            IUsersAdsCategory usersAdsCategory)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _allUsersAds = allUsersAds;
            _usersAdsCategory = usersAdsCategory;

            _selectList = _usersAdsCategory.GetSelectListItems;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<UsersAd> usersAds = _allUsersAds.UsersAds.OrderBy(x => x.Id);

            var userHomeViewModel = new UsersAdHomeViewModel
            {
                categoryViewName = "All categories",
                allUsersAds = usersAds,
                SelectList = _usersAdsCategory.UbdateSelectList(_selectList),
            };

            return View(userHomeViewModel);
        }

        [HttpGet]
        public IActionResult Item(int? id)
        {
            if (id != null)
            {
                return View(id.Value);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Index(UsersAdHomeViewModel model)
        {
            model.SelectList = _usersAdsCategory.UbdateSelectList(_selectList);
            model.categoryViewName = _usersAdsCategory.GetCategoryNameById(model.curCategoryId);
            model.allUsersAds = _allUsersAds.GetUsersAdsByCategoryId(model.curCategoryId);
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
