using AutoMapper;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class ProductVariantManager : CrudManager<ProductVariant, ProductVariantDto, CreateProductVariantDto, UpdateProductVariantDto>, IProductVariantService
    {
        public ProductVariantManager(IRepository<ProductVariant> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}