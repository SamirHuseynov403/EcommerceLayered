

using Ecommerce.BLL.DTOs.OrderItem;

namespace Ecommerce.BLL.DTOs.Product
{
    public class UpdateProductDto:BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public int CategoryId { get; set; }

        public int? BrandId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }
}
