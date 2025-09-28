using AutoMapper;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class ColorManager : CrudManager<Color, ColorDto, CreateColorDto, UpdateColorDto>, IColorService
    {
        public ColorManager(IRepository<Color> respository, IMapper mapper) : base(respository, mapper)
        {
           
        }

        public async Task<bool> AddColorAsync(CreateColorDto model)
        {
            var color = await Repository.GetAsync(c => c.Name.ToLower() == model.Name.ToLower());
            if (color != null) return false;

            var newColor= new Color
            {
                Name = model.Name,
                Code = model.Code
            };

           await Repository.AddAsync(newColor);

            return true;
        }

       
    }
}