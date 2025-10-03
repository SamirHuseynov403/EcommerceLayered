using AutoMapper;
using Ecommerce.BLL.Services;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Product;
using Ecommerce.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ISeasonEssentialService _seasonEssentialService;
        private readonly IMapper _mapper;

        public HomeController(IProductService productService, ISeasonEssentialService seasonEssentialService, IMapper mapper)
        {
            _productService = productService;
            _seasonEssentialService = seasonEssentialService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var listProductsSeason = await _productService.GetAllAsync(
    predicate: p => !p.IsDeleted
        && p.SeasonEssentials.Any(se => !se.IsDeleted),
    include: q => q
        .Include(p => p.Category)
        .Include(p => p.Brand)
        .Include(p => p.ProductImages.Where(img => !img.IsDeleted)) // 🔹 burda şəkillər gəlir
        .Include(p => p.ProductVariants.Where(v => !v.IsDeleted))
            .ThenInclude(v => v.Color)
        .Include(p => p.ProductVariants.Where(v => !v.IsDeleted))
            .ThenInclude(v => v.Size)
);




            var model = new HomeViewModel
            {
                Products = listProductsSeason.ToList()
            };
            return View(model);
        }

    }
}
