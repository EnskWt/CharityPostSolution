using CharityPost.Core.DataTransferObjects.AuthObjects;
using CharityPost.Core.Domain.Entities.IdentityEntities;
using CharityPost.Core.Enums.IdentityRelatedEnums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CharityPost.Presentation.Controllers
{
    [Route("/auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        [Authorize(Policy = "NotAuthorized")]
        [Route("register")]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "NotAuthorized")]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterObject registerObject)
        {
            if (ModelState.IsValid)
            {
                var user = registerObject.ToApplicationUser();

                var result = await _userManager.CreateAsync(user, registerObject.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    await AttachRoleToUser(user, UserRoles.User);

                    return RedirectToAction("Index", "Publications");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("RegisterError", error.Description);
                }
            }

            return View(registerObject);
        }

        [HttpGet]
        [Authorize(Policy = "NotAuthorized")]
        [Route("login")]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "NotAuthorized")]
        [Route("login")]
        public async Task<IActionResult> Login(LoginObject loginObject)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginObject.Username, loginObject.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Publications");
                }

                ModelState.AddModelError("LoginError", "Invalid login attempt");
            }

            return View(loginObject);
        }

        [HttpGet]
        [Route("new-author")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> BecomePublisher()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Index", "Publications");
            }

            await AttachRoleToUser(user, UserRoles.Publisher);

            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Articles");
        }

        [HttpGet]
        [Authorize]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Articles");
        }

        private async Task CreateRoleIfNotExist(UserRoles role)
        {
            if (await _roleManager.FindByNameAsync(role.ToString()) is null)
            {
                await _roleManager.CreateAsync(new ApplicationRole { Name = role.ToString() });
            }
        }

        private async Task AttachRoleToUser(ApplicationUser user, UserRoles role)
        {
            await CreateRoleIfNotExist(role);

            if (await _userManager.IsInRoleAsync(user, role.ToString()))
            {
                return;
            }

            await _userManager.AddToRoleAsync(user, role.ToString());
        }

        [AllowAnonymous]
        [Route("is-username-free")]
        public IActionResult IsUsernameFree(string username)
        {
            ApplicationUser? user = _userManager.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        [Route("is-email-free")]
        public IActionResult IsEmailFree(string email)
        {
            ApplicationUser? user = _userManager.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        [AllowAnonymous]
        [Route("is-phone-number-free")]
        public IActionResult IsPhoneNumberFree(string phoneNumber)
        {
            ApplicationUser? user = _userManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneNumber);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
