using AutoMapper;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Ecommerce.BLL.DataFile;

namespace Ecommerce.BLL.Manager
{
    public class ProductManager : CrudManager<Product, ProductDto, CreateProductDto, UpdateProductDto>, IProductService
    {
        public ProductManager(IRepository<Product> respository, IMapper mapper) : base(respository, mapper)
        {
        }

        public async Task<int> AddProductAsync(CreateProductDto model)
        {
            if (!model.ImageFile!.IsImage()) return 0;
            if (!model.ImageFile!.IsAllowedSize(1)) return 0;
            if (model.Price<0) return 0;
            
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

            return product.Id;
        }
        public async Task<bool> UpdateProductAsync(UpdateProductDto model)
        {
            var product = await Repository.GetByIdAsync(model.Id);
            if (product == null) return false;

            product.Name = model.Name;
            product.Description = model.Description;
            product.Price = model.Price;
            product.BrandId = model.BrandId;
            product.CategoryId = model.CategoryId;

            // Əgər yeni şəkil seçilibsə
            if (model.ImageFile != null)
            {
                if (!model.ImageFile.IsImage()) return false;
                if (!model.ImageFile.IsAllowedSize(1)) return false;

                string extension = Path.GetExtension(model.ImageFile.FileName).ToLower();
                var unicalName = await model.ImageFile.GenerateFile(PathConstants.ProductImagePath, extension);

                if (!string.IsNullOrEmpty(product.ImageUrl))
                {
                    var oldPath = Path.Combine(PathConstants.ProductImagePath, product.ImageUrl);
                    if (File.Exists(oldPath)) File.Delete(oldPath);
                }

                product.ImageUrl = unicalName;
            }

            await Repository.UpdateAsync(product);
            return true;
        }

    }
}