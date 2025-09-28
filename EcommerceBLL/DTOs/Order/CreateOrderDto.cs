using Ecommerce.BLL.DTOs.OrderItem;

namespace Ecommerce.BLL.DTOs.Order
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;

        public List<CreateOrderItemDto> OrderItems { get; set; } = [];
    }

}
