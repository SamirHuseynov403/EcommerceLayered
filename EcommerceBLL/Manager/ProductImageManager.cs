using AutoMapper;
using Ecommerce.BLL.DTOs.Bio;
using Ecommerce.BLL.DTOs.ProductImage;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class ProductImageManager : CrudManager<ProductImage, ProductImageDto, CreateProductImageDto, UpdateProductImageDto>, IProductImageService
    {
        public ProductImageManager(IRepository<ProductImage> respository, IMapper mapper) : base(respository, mapper)
        {
        }
    }
}