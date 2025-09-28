
namespace Ecommerce.DAL.Entities
{
    public class Category : Base
    {
        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }
        public Category? Parent { get; set; }

        public List<Category> SubCategories { get; set; } = [];
        public List<Product> Products { get; set; } = [];

    }
}
