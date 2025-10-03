
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductImage;

namespace Ecommerce.BLL.DTOs.ProductVariant
{
    public class ProductVariantDto : BaseDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;

        public int ColorId { get; set; }
        public ColorDto Color { get; set; } = null!;

        public int SizeId { get; set; }
        public SizeDto Size { get; set; } = null!;

        public int Quantity { get; set; }

        public List<ProductImageDto> Images { get; set; } = new();
    }
}
