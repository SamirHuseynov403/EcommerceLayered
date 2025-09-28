

namespace Ecommerce.BLL.DTOs.Order
{
    public class UpdateOrderDto : BaseDto
    {
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
    }

}
