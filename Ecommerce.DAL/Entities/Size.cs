
namespace Ecommerce.DAL.Entities
{
    public class Size : Base
    {
        public string? SizeProduct { get; set; }
        public List<ProductVariant> Variants { get; set; } = new();
    }
}
