using Ecommerce.BLL.DTOs.ProductImage;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IProductImageService : ICrudService<ProductImage, ProductImageDto, CreateProductImageDto, UpdateProductImageDto> { }
}




