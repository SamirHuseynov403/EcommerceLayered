
namespace Ecommerce.BLL.DTOs.ProductVariant
{
    public class ProductVariantDto : BaseDto
    {
        public string? Color { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}
