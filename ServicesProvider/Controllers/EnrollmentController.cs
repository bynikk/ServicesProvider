using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ServicesProvider.Models.Entities;
using ServicesProvider.Models.ViewModels;
using System.Security.Claims;
using ServicesProvider.Models;
using System.Collections.Generic;
using System.Linq;
using ServicesProvider.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ServicesProvider.Controllers
{
    [AllowAnonymous]
    public class EnrollmentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly ValidatorViewModel _validator = new ();

        public EnrollmentController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (result.Succeeded)
            {
                if (_userManager.HasClaim(user, ClaimTypes.Role, RolesModel.Administrator))
                {
                    model.ReturnUrl = "/Admin/Index";
                }
                else
                {
                    model.ReturnUrl = "/Home/Index";
                }
                
                return Redirect(model.ReturnUrl);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult SignUp(string returnUrl)
        {
            return View(new SignUpViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SignUp(SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userManager.FindByNameAsync(model.UserName) != null)
            {
                ModelState.AddModelError("", $"User with this '{model.UserName}' username already exist");
                return View(model);
            }

            string exMessage = string.Empty;

            if (!_validator.ValidateSignUpViewModel(model))
            {
                ModelState.AddModelError("", "Server Error");
                return View(model);
            }

            var user = new ApplicationUser(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, RolesModel.User));
                Redirect("/Home/Index");
            }
            

            return View(model);
        }

        private async Task Authorize(ApplicationUser user)
        {
            IEnumerable<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, RolesModel.User),
            };

            var id = new ClaimsIdentity(claims, "Application cocie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
