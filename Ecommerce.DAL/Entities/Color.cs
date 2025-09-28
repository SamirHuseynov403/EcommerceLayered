
namespace Ecommerce.DAL.Entities
{
    public class Color : Base
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public List<ProductVariant> Variants { get; set; } = new();
    }
}
