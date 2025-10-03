using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.MVC.Areas.SuperAdmin.Models.Details
{
    public class DetailsProductViewModel
    {
        public int Id { get; set; }
        public string? ColorName { get; set; }
        public string? SizeName { get; set; }
        public string? ImageName { get; set; }
        public int Quantity { get; set; }
    }
    public class DetailsProductListViewModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = null!;
        public string? ProductName { get; set; }
        public string? ImageName { get; set; }
        public IFormFile ImageFile { get; set; } = null!;
        public int ColorId { get; set; }
        public int Quantity { get; set; }
        public List<DetailsProductViewModel> DetailsProducts { get; set; } = new List<DetailsProductViewModel>();
        public List<SelectListItem> ListCategory { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ListColor { get; set; } = new List<SelectListItem>();
        public List<int> SelectedSizes { get; set; } = new();
        public List<SelectListItem> ListSize { get; set; } = new();
    }
}
