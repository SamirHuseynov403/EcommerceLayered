using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.SeasonEssentials;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Details;
using Ecommerce.MVC.Areas.SuperAdmin.Models.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Models
{
    public class HomeViewModel
    {
        public List<SeasonEssentialViewModel> SeasonEssentials { get; set; } = new List<SeasonEssentialViewModel>();
        public List<ProductDto> Products { get; set; } = new List<ProductDto>();
        public List<DetailsProductViewModel> DetailsProducts { get; set; } = new List<DetailsProductViewModel>();
    }
    public class SeasonEssentialViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }

        public List<ColorDto> Colors { get; set; } = new List<ColorDto>();
    }
    
}
