using AutoMapper;
using Ecommerce.BLL.DTOs.SeasonEssentials;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class SeasonEssentialManager : CrudManager<SeasonEssential, SeasonEssentialDto, CreateSeasonEssentialDto, UpdateSeasonEssentialDto>, ISeasonEssentialService
    {
        public SeasonEssentialManager(IRepository<SeasonEssential> respository, IMapper mapper) : base(respository, mapper)
        {
        }
      
    }
}
