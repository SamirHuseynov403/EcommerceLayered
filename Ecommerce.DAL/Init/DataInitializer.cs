using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL.Init
{
    public class DataInitializer
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataInitializer(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task InitalizeAsync()
        {
            // Rolları yoxla və əlavə et
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole("User"));

            // Admin hesabı yoxdursa, yarat
            var admin = await _userManager.FindByEmailAsync("admin@site.com");
            if (admin == null)
            {
                var newAdmin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@site.com",
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(newAdmin, "Admin123!");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(newAdmin, "Admin");
                }
            }
        }
    }

}
