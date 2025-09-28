
namespace Ecommerce.DAL.Entities
{
    public class Coupon : Base
    {
        public string Code { get; set; } = null!;
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsActive { get; set; }
    }
}
