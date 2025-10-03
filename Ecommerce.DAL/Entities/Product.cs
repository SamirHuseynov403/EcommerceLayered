
namespace Ecommerce.DAL.Entities
{
    public class Product : Base
    {
        public required string ProductCode { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string? ImageUrl { get; set; }
        public int GenderId { get; set; } = 0;
        public Gender Gender { get; set; } 
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int? BrandId { get; set; }
        public Brand? Brand { get; set; }

        public List<OrderItem> OrderItems { get; set; } = [];
        public List<ProductImage> ProductImages { get; set; } = [];
        public List<ProductVariant> ProductVariants { get; set; } = [];
        public List<SeasonEssential> SeasonEssentials { get; set; } = [];

    }
    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2

    }
}
