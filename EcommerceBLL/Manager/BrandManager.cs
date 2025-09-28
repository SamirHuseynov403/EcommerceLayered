using AutoMapper;
using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class BrandManager : CrudManager<Brand, BrandDto, BrandCreateDto, BrandUpdateDto>, IBrandService
    {
        public BrandManager(IRepository<Brand> respository, IMapper mapper) : base(respository, mapper)
        {
        }
        public async Task<BrandDto?> GetByNameAsync(string name)
        {
            var brand = await Repository.GetAsync(c => c.Name == name);
            return Mapper.Map<BrandDto?>(brand);
        }
    
    }
}
