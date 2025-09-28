
namespace Ecommerce.BLL.DTOs.WishList
{
    public class UpdateWishlistDto : BaseDto
    {
        public string UserId { get; set; } = null!;
        public int ProductId { get; set; }
    }
}
