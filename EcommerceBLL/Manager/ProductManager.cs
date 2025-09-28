using AutoMapper;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using OganiMasterMVC.Areas.Admin.Data;

namespace Ecommerce.BLL.Manager
{
    public class ProductManager : CrudManager<Product, ProductDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        public ProductManager(IRepository<Product> respository, IMapper mapper) : base(respository, mapper)
        {
        }

        public async Task<bool> AddProductAsync(CreateProductDto model)
        {
            if (!model.ImageFile!.IsImage()) return false;
            if (!model.ImageFile!.IsAllowedSize(1)) return false;
            string extension = Path.GetExtension(model.ImageFile!.FileName).ToLower();
            var unicalName = await model.ImageFile.GenerateFile(PathConstants.ProductImagePath, extension);

            var product = new Product
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                Stock = model.Stock,
                CategoryId = model.CategoryId,
                BrandId = model.BrandId,
                ImageUrl = unicalName,
            };

            await Repository.AddAsync(product);

            return true;
        }
    }
}