using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class BrandController : AdminController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var listBrands =await _brandService.GetAllAsync();
            return View(listBrands);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(BrandCreateDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                return View(brandDto);
            }
            var existBrand = await _brandService.GetByNameAsync(brandDto.Name!);

            if (existBrand != null)
            {
                ModelState.AddModelError("Name", "Bu Brand bazada movcuddur.");
                return View(brandDto);
            }

            await _brandService.CreateAsync(brandDto);
            return RedirectToAction("Index");
        }
    }
}
