
namespace Ecommerce.DAL.Entities
{
    public class Brand : Base
    {
        public string Name { get; set; } = null!;

        public List<Product> Products { get; set; } = [];
    }
}
