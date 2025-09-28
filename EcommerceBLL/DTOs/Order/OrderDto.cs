

using Ecommerce.BLL.DTOs.OrderItem;

namespace Ecommerce.BLL.DTOs.Order
{
    public class OrderDto : BaseDto
    {
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;

        public List<OrderItemDto> OrderItems { get; set; } = [];
    }

}
