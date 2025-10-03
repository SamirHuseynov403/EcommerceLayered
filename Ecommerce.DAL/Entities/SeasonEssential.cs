
namespace Ecommerce.DAL.Entities
{
    public class SeasonEssential : Base
    {
        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
