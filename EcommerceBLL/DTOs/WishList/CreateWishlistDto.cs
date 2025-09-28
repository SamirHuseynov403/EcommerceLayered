
namespace Ecommerce.BLL.DTOs.WishList
{
    public class CreateWishlistDto
    {
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
