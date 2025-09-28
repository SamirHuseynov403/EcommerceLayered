using Ecommerce.BLL.DTOs.Product;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IProductService : ICrudService<Product, ProductDto, CreateProductDto, UpdateProductDto> 
    {
        Task<bool> AddProductAsync(CreateProductDto model);
    }
}




