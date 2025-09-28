using AutoMapper;
using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class SizeManager : CrudManager<Size, SizeDto, CreateSizeDto, UpdateSizeDto>, ISizeService
    {
        public SizeManager(IRepository<Size> respository, IMapper mapper) : base(respository, mapper)
        {
        }
        public async Task<SizeDto?> GetByNameAsync(string name)
        {
            var size = await Repository.GetAsync(c => c.SizeProduct!.ToLower() == name.ToLower());
            return Mapper.Map<SizeDto?>(size);
        }
    }
}