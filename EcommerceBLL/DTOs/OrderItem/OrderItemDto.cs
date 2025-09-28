
namespace Ecommerce.BLL.DTOs.OrderItem
{
    public class OrderItemDto : BaseDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? CuponCode { get; set; }
    }
}
