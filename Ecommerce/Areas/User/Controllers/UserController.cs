using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Areas.User.Controllers
{
    public class UserController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
