
namespace Ecommerce.BLL.DTOs.ProductImage
{
    public class CreateProductImageDto
    {
        public string ImageUrl { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int? ProductVariantId { get; set; }
    }
}
