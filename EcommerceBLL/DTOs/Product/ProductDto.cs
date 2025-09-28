using Ecommerce.BLL.DTOs.OrderItem;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.BLL.DTOs.Product
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public IFormFile ImageFile { get; set; } = null!;

        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}
