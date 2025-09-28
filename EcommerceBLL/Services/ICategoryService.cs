using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;

public interface ICategoryService : ICrudService<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
    Task<CategoryDto?> GetByNameAsync(string name);
}
