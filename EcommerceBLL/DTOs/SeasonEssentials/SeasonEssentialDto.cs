
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductVariant;

namespace Ecommerce.BLL.DTOs.SeasonEssentials
{
    public class SeasonEssentialDto:BaseDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }

        public List<ProductVariantDto> Variants { get; set; } = new List<ProductVariantDto>();
    }
}
