

using Ecommerce.BLL.DTOs.OrderItem;
using Microsoft.AspNetCore.Http;

namespace Ecommerce.BLL.DTOs.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public IFormFile? ImageFile { get; set; }
        public IFormFile[]? ImageFiles { get; set; }
        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}
