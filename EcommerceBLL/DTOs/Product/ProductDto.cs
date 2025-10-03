using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.DTOs.OrderItem;
using Ecommerce.BLL.DTOs.ProductImage;
using Ecommerce.BLL.DTOs.ProductVariant;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.BLL.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public required string ProductCode { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile ImageFile { get; set; } = null!;
        public Gender? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;

        public int? BrandId { get; set; }
        public BrandDto? Brand { get; set; }

        public int? ProductVariantId { get; set; }
        public List<ProductImageDto> ProductImages { get; set; } = [];
        public List<ProductVariantDto> ProductVariants { get; set; } = [];

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2

    }
}
