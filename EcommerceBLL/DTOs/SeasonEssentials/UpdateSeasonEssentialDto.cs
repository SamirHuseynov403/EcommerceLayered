
using Ecommerce.BLL.DTOs.Product;

namespace Ecommerce.BLL.DTOs.SeasonEssentials
{
    public class UpdateSeasonEssentialDto : BaseDto
    {
        public int ProductId { get; set; }
        public ProductDto Product { get; set; } = null!;
    }
}
