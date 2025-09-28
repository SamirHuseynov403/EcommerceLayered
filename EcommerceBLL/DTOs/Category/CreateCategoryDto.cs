
namespace Ecommerce.BLL.DTOs.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = null!;

        public int? ParentId { get; set; }
    }
}
