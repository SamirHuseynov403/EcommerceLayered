using Ecommerce.DAL.Entities;
using Ecommerce.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new AppUser
            {
                FullName = model.FullName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                // Admin rolunu ver (ilk dəfə qeydiyyatdan keçən üçün)
                await _userManager.AddToRoleAsync(user, "Admin");

                // İstifadəçini login et
                await _signInManager.SignInAsync(user, isPersistent: false);

                // Əgər Admin-dir → SuperAdmin Dashboard-a yönləndir
                return RedirectToAction("Index", "Dashboard", new { area = "SuperAdmin" });
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            // həm Email, həm də UserName dəstəklə
            AppUser user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // Admin
                    if (await _userManager.IsInRoleAsync(user, "Admin"))
                        return RedirectToAction("Index", "Dashboard", new { area = "SuperAdmin" });

                    // User
                    if (await _userManager.IsInRoleAsync(user, "User"))
                        return RedirectToAction("Index", "Home", new { area = "User" });

                    // Default yönləndirmə
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Ad və ya şifrə yanlışdır");
            return View(model);
        }


        public IActionResult ChangePassword()
        {
            return View();
        }
    }
}
