using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.Services;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class ProductController : AdminController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IBrandService _brandService;

        public ProductController(IProductService productService, ICategoryService categoryService, IColorService colorService, ISizeService sizeService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
            _sizeService = sizeService;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            var listProducts =await _productService.GetAllAsync();
            var model = new ProductViewModel
            {
                Products = listProducts.ToList(),
            };
            return View(model);
        }
        public async Task<IActionResult> create()
        {
            var listCategory = (await _categoryService.GetAllAsync())
        .Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
            var listColor = (await _colorService.GetAllAsync())
        .Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        }).ToList();
            var listSize = (await _sizeService.GetAllAsync())
        .Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.SizeProduct
        }).ToList();
            var listBrand = (await _brandService.GetAllAsync())
        .Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = s.Name
        }).ToList();

            var model = new ProductViewModel
            {
                ListCategory = listCategory,
                ListColor = listColor,
                ListSize = listSize,
                ListBrand = listBrand
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> create(CreateProductDto model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var isSucceeded =await _productService.AddProductAsync(model);
            if (!isSucceeded)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View(model);
            }
            return RedirectToAction("Index");
        }
    }
}
