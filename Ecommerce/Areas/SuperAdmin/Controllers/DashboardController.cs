using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class DashboardController : AdminController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
