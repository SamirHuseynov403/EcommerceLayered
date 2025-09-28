
namespace Ecommerce.DAL.Entities
{
    public class OrderItem : Base
    {
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string? CuponCode { get; set; }
    }
}
