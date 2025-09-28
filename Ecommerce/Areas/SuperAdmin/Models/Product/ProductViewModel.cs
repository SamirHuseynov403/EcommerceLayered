using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Areas.SuperAdmin.Models.Product
{
    public class ProductViewModel
    {
        public string Name { get; set; } = null!;
        public IFormFile ImageFile { get; set; } = null!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int Stock { get; set; }
        //public ProductDto Product { get; set; } = new ProductDto();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public int CategoryId { get; set; }
        public int? BrandId { get; set; }

        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }

        public List<SelectListItem> ListCategory { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListColor { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListBrand { get; set; } = new List<SelectListItem>();
        public List<ProductVariantDto> ProductVariants { get; set; } = [];

        public List<int> SelectedSizes { get; set; } = new();
        public List<SelectListItem> ListSize { get; set; } = new();

        public int? ProductId { get; set; }
        public int ColorId { get; set; }
    }
}
