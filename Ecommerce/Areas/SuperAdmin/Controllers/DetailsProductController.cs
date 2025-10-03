using AutoMapper;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductImage;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.BLL.Services;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Details;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.MVC.Areas.SuperAdmin.Controllers
{
    public class DetailsProductController : AdminController
    {
        private readonly IProductService _productService;
        private readonly IProductVariantService _productVariantService;
        private readonly IColorService _colorService;
        private readonly ISizeService _sizeService;
        private readonly IProductImageService _productImageService;
        private readonly IMapper _mapper;

        public DetailsProductController(IProductVariantService productVariantService, IColorService colorService, ISizeService sizeService, IProductService productService, IMapper mapper, IProductImageService productImageService)
        {
            _productVariantService = productVariantService;
            _colorService = colorService;
            _sizeService = sizeService;
            _productService = productService;
            _mapper = mapper;
            _productImageService = productImageService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Details(int id)
        {
            var productName = (await _productService.GetAsync(p => p.Id == id && !p.IsDeleted))?.Name;
            var productCode = (await _productService.GetAsync(p => p.Id == id && !p.IsDeleted))?.ProductCode;
            var list = await _productVariantService.GetAllAsync(
            predicate: s => s.ProductId == id && !s.IsDeleted,
            include: q => q
        .Include(v => v.Color)
        .Include(v => v.Size)
        .Include(v => v.Product)
            .ThenInclude(p => p.ProductImages)
);

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
            var model = new DetailsProductListViewModel
            {
                ProductId=id,
                ProductName = productName,
                ProductCode= productCode!,
                DetailsProducts = list.Select(s => new DetailsProductViewModel
                {
                    Id = s.Id,
                    ColorName = s.Color?.Name,
                    SizeName = s.Size?.SizeProduct,
                    ImageName = s.Product.ProductImages
                    .FirstOrDefault(img =>
                        img.ProductId == s.ProductId &&
                        img.ColorId == s.ColorId &&
                        !img.IsDeleted)
                    ?.ImageUrl,
                    Quantity = s.Quantity
                }).ToList(),
                ListColor = listColor,
                ListSize = listSize
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(DetailsProductListViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        // Yenidən rəng və ölçü listlərini doldururuq
        //        model.ListColor = (await _colorService.GetAllAsync())
        //            .Select(c => new SelectListItem
        //            {
        //                Value = c.Id.ToString(),
        //                Text = c.Name
        //            }).ToList();

        //        model.ListSize = (await _sizeService.GetAllAsync())
        //            .Select(s => new SelectListItem
        //            {
        //                Value = s.Id.ToString(),
        //                Text = s.SizeProduct
        //            }).ToList();

        //        return View("Details", model);
        //    }

        //    for (var i = 0; i < model.SelectedSizes.Count; i++)
        //    {
        //        var sizeId = model.SelectedSizes[i];

        //        var existingVariant = await _productVariantService
        //            .GetAsync(v => v.ProductId == model.ProductId
        //                        && v.ColorId == model.ColorId
        //                        && v.SizeId == sizeId
        //                        && !v.IsDeleted);

        //        if (existingVariant != null)
        //        {
        //            var updateDto = new UpdateProductVariantDto
        //            {
        //                Id = existingVariant.Id,
        //                ProductId = existingVariant.ProductId,
        //                ColorId = existingVariant.ColorId,
        //                SizeId = existingVariant.SizeId,
        //                Quantity = existingVariant.Quantity + model.Quantity
        //            };

        //            await _productVariantService.UpdateAsync(existingVariant.Id, updateDto);
        //        }
        //        else
        //        {
        //            var newVariant = new CreateProductVariantDto
        //            {
        //                ProductId = model.ProductId,
        //                ColorId = model.ColorId,
        //                SizeId = sizeId,
        //                Quantity = model.Quantity
        //            };

        //            await _productVariantService.CreateAsync(newVariant);
        //        }
        //    }

        //    return RedirectToAction("Details", new { id = model.ProductId });
        //}
        [HttpPost]
        public async Task<IActionResult> Create(DetailsProductListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.ListColor = (await _colorService.GetAllAsync())
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();

                model.ListSize = (await _sizeService.GetAllAsync())
                    .Select(s => new SelectListItem
                    {
                        Value = s.Id.ToString(),
                        Text = s.SizeProduct
                    }).ToList();

                return View("Details", model);
            }

            foreach (var sizeId in model.SelectedSizes)
            {
                var existingVariant = await _productVariantService.GetAsync(v =>
                    v.ProductId == model.ProductId &&
                    v.ColorId == model.ColorId &&
                    v.SizeId == sizeId &&
                    !v.IsDeleted);

                int variantId;

                if (existingVariant != null)
                {
                    var updateDto = new UpdateProductVariantDto
                    {
                        Id = existingVariant.Id,
                        ProductId = existingVariant.ProductId,
                        ColorId = existingVariant.ColorId,
                        SizeId = existingVariant.SizeId,
                        Quantity = existingVariant.Quantity + model.Quantity
                    };

                    await _productVariantService.UpdateAsync(existingVariant.Id, updateDto);
                    variantId = existingVariant.Id;
                }
                else
                {
                    var newVariant = new CreateProductVariantDto
                    {
                        ProductId = model.ProductId,
                        ColorId = model.ColorId,
                        SizeId = sizeId,
                        Quantity = model.Quantity
                    };

                    var createdVariant = await _productVariantService.CreateAsync(newVariant);
                    variantId = createdVariant.Id;

                }

                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var existingImage = await _productImageService.GetAsync(img =>
                        img.ProductId == model.ProductId &&
                        img.ColorId == model.ColorId &&   
                        !img.IsDeleted);

                    if (existingImage == null) 
                    {
                        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                        var filePath = Path.Combine("wwwroot/Admin/images/ProductImages", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ImageFile.CopyToAsync(stream);
                        }

                        var newImage = new CreateProductImageDto
                        {
                            ProductId = model.ProductId,
                            ProductVariantId = variantId,   
                            ColorId = model.ColorId,       
                            ImageUrl = fileName,
                            IsMain = true
                        };

                        await _productImageService.CreateAsync(newImage);
                    }
                }


            }

            return RedirectToAction("Details", new { id = model.ProductId });
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id,int ProductId)
        {
            var listProductVAriant = await _productVariantService.GetByIdAsync(id);

            if (listProductVAriant == null) { return RedirectToAction("Index"); }


            var dtoVariant = _mapper.Map<UpdateProductVariantDto>(listProductVAriant);

            await _productVariantService.DeleteAsync(id);

            return RedirectToAction("Details", new { id = ProductId });
        }

    }
}
