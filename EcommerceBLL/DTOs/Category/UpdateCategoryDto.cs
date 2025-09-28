
namespace Ecommerce.BLL.DTOs.Category
{
    public class UpdateCategoryDto : BaseDto
    {
        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }
    }
}
