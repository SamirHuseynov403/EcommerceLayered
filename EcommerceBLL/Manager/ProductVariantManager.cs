using AutoMapper;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;
using Ecommerce.DAL.Repositories.Migrations;

namespace Ecommerce.BLL.Manager
{
    public class ProductVariantManager
    : CrudManager<ProductVariant, ProductVariantDto, CreateProductVariantDto, UpdateProductVariantDto>,
      IProductVariantService
    {
        private readonly IRepository<ProductVariant> _repository;
        private readonly IMapper _mapper;

        public ProductVariantManager(IRepository<ProductVariant> repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<ProductVariantDto> CreateAsync(CreateProductVariantDto model)
        {
            var entity = _mapper.Map<ProductVariant>(model);

            await _repository.AddAsync(entity);

            return _mapper.Map<ProductVariantDto>(entity);
        }
    }


}