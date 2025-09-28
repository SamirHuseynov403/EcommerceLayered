
namespace Ecommerce.BLL.DTOs.Category
{
    public class CategoryDto : BaseDto
    {
        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }

        public List<CategoryDto> SubCategories { get; set; } = [];
        //public List<CategoryDto> Products { get; set; } = [];
    }
}
