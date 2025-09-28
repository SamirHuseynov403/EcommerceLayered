
namespace Ecommerce.DAL.Entities
{
    public class ProductVariant : Base
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;

        public int ColorId { get; set; }
        public Color Color { get; set; } = null!;

        public int SizeId { get; set; }
        public Size Size { get; set; } = null!;

        public int Quantity { get; set; }

        public List<ProductImage> Images { get; set; } = new();
    }

}
