using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Areas.SuperAdmin.Models.Product
{
    public class UpdateProductViewModel
    {
        public string Name { get; set; } = null!;
        public string? CoverImageUrl { get; set; }
        public List<string> ImageUrls { get; set; } = new List<string>();
        public IFormFile? ImageFile { get; set; }
        public IFormFile[]? ImageFiles { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public decimal? DiscountPercent { get; set; }
        public int? CategoryId { get; set; }

        public List<SelectListItem> ListCategory { get; set; } = new List<SelectListItem>();
    }
}
