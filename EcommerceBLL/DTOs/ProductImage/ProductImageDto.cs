
namespace Ecommerce.BLL.DTOs.ProductImage
{
    public class ProductImageDto : BaseDto
    {
        public string ImageUrl { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}
