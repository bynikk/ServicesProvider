using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Models;
using System.Threading.Tasks;
using ServicesProvider.Models.Entities;

namespace ServicesProvider.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize(Policy = RolesModel.Administrator)]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = RolesModel.Administrator)]
        public IActionResult Administrator()
        {
            return View();
        }
    }
}

