
namespace Ecommerce.BLL.DTOs.ProductImage
{
    public class CreateProductImageDto
    {
        public string ImageUrl { get; set; } = null!;
        public bool IsMain { get; set; }
        public int ProductId { get; set; }
    }
}
