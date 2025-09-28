using Ecommerce.BLL.DTOs.Bio;
using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.DTOs.Category;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IBrandService:ICrudService<Brand, BrandDto,BrandCreateDto,BrandUpdateDto>
    {
        Task<BrandDto?> GetByNameAsync(string name);
    }
}




