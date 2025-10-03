using System.ComponentModel.DataAnnotations;

namespace Ecommerce.MVC.Models
{
    public class LoginViewModel
    {
        public required string UserName { get; set; }
       /// <summary>
       /// public required string Email { get; set; }
       /// </summary>
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
