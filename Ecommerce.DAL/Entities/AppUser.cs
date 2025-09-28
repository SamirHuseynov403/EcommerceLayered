using Microsoft.AspNetCore.Identity;

namespace Ecommerce.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
