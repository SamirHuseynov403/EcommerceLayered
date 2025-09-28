
namespace Ecommerce.DAL.Entities
{
    public class Order : Base
    {
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; } = null!;
        public AppUser? User { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];
    }
}
