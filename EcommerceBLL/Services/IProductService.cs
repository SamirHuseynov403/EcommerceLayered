using Ecommerce.BLL.DTOs.Product;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface IProductService : ICrudService<Product, ProductDto, CreateProductDto, UpdateProductDto> 
    {
        Task<int> AddProductAsync(CreateProductDto model);
        Task<bool> UpdateProductAsync(UpdateProductDto model);
    }
}




