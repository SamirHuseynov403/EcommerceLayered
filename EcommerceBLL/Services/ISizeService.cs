using Ecommerce.BLL.DTOs.Color;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface ISizeService : ICrudService<Size, SizeDto, CreateSizeDto, UpdateSizeDto>
    {
        Task<SizeDto?> GetByNameAsync(string name);
    }
}




