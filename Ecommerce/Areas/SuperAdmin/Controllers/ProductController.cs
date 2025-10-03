using AutoMapper;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.BLL.Services;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    [Area("SuperAdmin")]
    public class ProductController : AdminController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IBrandService _brandService;
        private readonly IProductVariantService _productVariantService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, ICategoryService categoryService, IColorService colorService, ISizeService sizeService, IBrandService brandService, IMapper mapper, IProductVariantService productVariantService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _colorService = colorService;
            _sizeService = sizeService;
            _brandService = brandService;
            _mapper = mapper;
            _productVariantService = productVariantService;
        }

        public async Task<IActionResult> Index()
        {
            var listProducts = await _productService.GetAllAsync(
            predicate: p => !p.IsDeleted,
            include: q => q
        .Include(p => p.Category)
        .Include(p => p.Brand)
        .Include(p => p.ProductVariants.Where(v => !v.IsDeleted))
            );

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
                ListBrand = listBrand
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> create(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var dto = new CreateProductDto
            {
                ProductCode = model.ProductCode,
                Name = model.Name,
                Description = model.Description!,
                Price = model.Price,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                ImageFile = model.ImageFile
            };

            var isSucceeded = await _productService.AddProductAsync(dto);
            if (isSucceeded == 0)
            {
                ModelState.AddModelError("", "Xəta baş verdi");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var listProdduct = await _productService.GetByIdAsync(id);
            var listProductVAriant = await _productVariantService.GetByIdAsync(id);

            if (listProdduct == null) { return RedirectToAction("Index"); }

            listProdduct.IsDeleted = true;

            var dtoProdyct = _mapper.Map<UpdateProductDto>(listProdduct);

            await _productService.UpdateAsync(id, dtoProdyct);

            if (listProductVAriant != null)
            {
                listProductVAriant.IsDeleted = true;
                var dtoVariant = _mapper.Map<UpdateProductVariantDto>(listProductVAriant);
                await _productVariantService.UpdateAsync(id, dtoVariant);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetAsync(
                     predicate: p => !p.IsDeleted && p.Id == id,
                     include: q => q
                         .Include(p => p.Category!)
                         .Include(p => p.Brand!)
                         .Include(p => p.ProductVariants.Where(v => !v.IsDeleted)),
                     AsNoTracking: true
                 );

            var model = new UpdateProductViewModel
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ListBrand = (await _brandService.GetAllAsync())
        .Select(b => new SelectListItem
        {
            Value = b.Id.ToString(),
            Text = b.Name
        })
        .ToList(),

                ListCategory = (await _categoryService.GetAllAsync())
        .Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = c.Name
        })
        .ToList()

            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Dropdown-ları yenidən doldurmaq lazımdır
                model.ListBrand = (await _brandService.GetAllAsync())
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Name
                    }).ToList();

                model.ListCategory = (await _categoryService.GetAllAsync())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                return View(model);
            }

            if (model.Quantity <= 0)
            {
                ModelState.AddModelError("Quantity", "Miqdar 0-dan böyük olmalıdır.");
                return View(model);
            }

            var updateDto = new UpdateProductDto
            {
                Id = model.ProductId,
                Name = model.Name,
                Description = model.Description!,
                Price = model.Price,
                BrandId = model.BrandId,
                CategoryId = model.CategoryId,
                ImageFile = model.ImageFile // null ola bilər, service bunu idarə edir
            };

            // UpdateProductAsync çağırmaq lazımdır
            var isSucceeded = await _productService.UpdateProductAsync(updateDto);

            if (!isSucceeded)
            {
                // Dropdown-ları error zamanı da doldur
                model.ListBrand = (await _brandService.GetAllAsync())
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Name
                    }).ToList();

                model.ListCategory = (await _categoryService.GetAllAsync())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                ModelState.AddModelError("", "Xəta baş verdi.");
                return View(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CheckCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                return Json(new { exists = false });

            // ProductCode string-dir, birbaşa yoxlaya bilərik
            var product = await _productService.GetAsync(p => p.ProductCode == code && !p.IsDeleted);

            return Json(new { exists = product != null });
        }
    }
}
