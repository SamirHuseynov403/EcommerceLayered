using AutoMapper;
using Ecommerce.BLL.DTOs.Bio;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class BioManager : CrudManager<Bio, BioDto, CreateBioDto, UpdateBioDto>, IBioService
    {
        public BioManager(IRepository<Bio> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}