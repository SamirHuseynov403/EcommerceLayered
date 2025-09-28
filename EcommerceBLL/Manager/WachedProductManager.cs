using AutoMapper;
using Ecommerce.BLL.DTOs.WachedProduct;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class WachedProductManager : CrudManager<WachedProduct, WachedProductDto, CreateWachedProductDto, UpdateWachedProductDto>, IWachedProductService
    {
        public WachedProductManager(IRepository<WachedProduct> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}