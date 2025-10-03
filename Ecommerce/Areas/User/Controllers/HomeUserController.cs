using Ecommerce.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Areas.User.Controllers
{
    public class HomeUserController : UserController
    {
        private readonly IProductService productService;

        public HomeUserController(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
