using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        }
        
        [Route("Home/Index")]
        [Route("Home/Index/{categoryId}")]
        public IActionResult Index(int categoryId)
        {
            IEnumerable<UsersAd> usersAds = null;
            int curCategory = 0;
            string curCategoryName = string.Empty;

            if (categoryId == default)
            {
                usersAds = _allUsersAds.UsersAds.OrderBy(x => x.Id);
            }
            else
            {
                if (categoryId == (int)CategoryNames.EnumOfCategoryNames.Programming)
                {
                    usersAds = _allUsersAds.UsersAds.Where(x => x.CategoryId == categoryId).OrderBy(x => x.Id);
                    curCategoryName = CategoryNames.Programming;
                }
                else if (categoryId == (int)CategoryNames.EnumOfCategoryNames.Design)
                {
                    usersAds = _allUsersAds.UsersAds.Where(x => x.CategoryId == categoryId).OrderBy(x => x.Id);
                    curCategoryName = CategoryNames.Design;
                }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               

                curCategory = categoryId;
            }


            var userHomeViewModel = new UsersAdHomeViewModel
            {
                allUsersAds = usersAds,
                curCategory = curCategory,
                categoryViewName = curCategoryName,
            };

            return View(userHomeViewModel);
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
