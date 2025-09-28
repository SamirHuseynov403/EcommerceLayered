
namespace Ecommerce.DAL.Entities
{
    public class WachedProduct : Base
    {
        public string? UserId { get; set; }
        public AppUser? User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

    }
}
