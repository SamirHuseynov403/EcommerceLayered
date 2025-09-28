using AutoMapper;
using Ecommerce.BLL.DTOs.Category;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class CategoryManager : CrudManager<Category, CategoryDto, CreateCategoryDto, UpdateCategoryDto>, ICategoryService
    {
        public CategoryManager(IRepository<Category> respository, IMapper mapper) : base(respository, mapper)
        {
        }
        public async Task<CategoryDto?> GetByNameAsync(string name)
        {
            var category = await Repository.GetAsync(c => c.Name.ToLower() == name.ToLower());
            return Mapper.Map<CategoryDto?>(category);
        }

    }
}
