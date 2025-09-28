
namespace Ecommerce.BLL.DTOs.Currency
{
    public class UpdateCurrencyDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Symbol { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
   
}
