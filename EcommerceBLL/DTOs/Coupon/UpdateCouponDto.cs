
namespace Ecommerce.BLL.DTOs.Coupon
{
    public class UpdateCouponDto : BaseDto
    {
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
