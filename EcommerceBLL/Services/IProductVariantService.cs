using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IProductVariantService : ICrudService<ProductVariant, ProductVariantDto, CreateProductVariantDto, UpdateProductVariantDto> { }
}




