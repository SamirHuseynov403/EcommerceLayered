
namespace Ecommerce.BLL.DTOs.Coupon
{
    public class CreateCouponDto
    {
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
