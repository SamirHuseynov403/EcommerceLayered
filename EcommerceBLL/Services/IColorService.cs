using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IColorService : ICrudService<Color, ColorDto, CreateColorDto, UpdateColorDto>
    {
        Task<bool> AddColorAsync(CreateColorDto model);
    }
}




