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

namespace ServicesProvider.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public EnrollmentController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
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

        [AllowAnonymous]
        public IActionResult SignUp(string returnUrl)
        {
            return View(new SignUpViewModel() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
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

            var user = new ApplicationUser(model);

            
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, RolesModel.User));
                Redirect("/Home/Index");
            }
            

            return View(model);
        }

        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
        }
    }
}
