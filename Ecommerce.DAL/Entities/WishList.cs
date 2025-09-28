
namespace Ecommerce.DAL.Entities
{
    public class WishList : Base
    {
        public string UserId { get; set; } = null!;
        public AppUser? User { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

    }
}
