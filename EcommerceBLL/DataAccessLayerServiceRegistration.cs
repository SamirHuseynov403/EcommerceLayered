using Ecommerce.BLL.Manager;
using Ecommerce.BLL.Mapping;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;
using Ecommerce.DAL.Repositories.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.BLL
{
    public static class DataAccessLayerServiceRegistration
    {
        public static IServiceCollection AddDAL(this IServiceCollection services, string? cs)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(cs));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IBioRepository,BioRepository>();

            services.AddScoped<IBrandRepository, BrandRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICouponRepository, CouponRepository>();

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();

            services.AddScoped<ILanguageRepository, LanguageRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<IOrderItemRepository, OrderItemRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<IProductImageRepository, ProductImageRepository>();

            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();

            services.AddScoped<ISocialRepository, SocialRepository>();

            services.AddScoped<IWachedProductRepository, WachedProductRepository>();

            services.AddScoped<IWishListRepository, WishListRepository>();

            services.AddScoped<IColorRepository, ColorRepository>();

            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISeasonEssentialRepository, SeasonEssentialRepository>();

            return services;
        }
    }
    public static class BusinessLogicLayerServiceRegistration
    {
        public static IServiceCollection AddBLL(this IServiceCollection services, string? connectionString)
        {
            services.AddDAL(connectionString);

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            services.AddScoped<IBioService, BioManager>();

            services.AddScoped<IBioService, BioManager>();

            services.AddScoped<IBrandService, BrandManager>();

            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddScoped<ICouponService, CouponManager>();

            services.AddScoped<ICurrencyService, CurrencyManager>();

            services.AddScoped<ILanguageService, LanguageManager>();

            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<IOrderItemService, OrderItemManager>();

            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IProductImageService, ProductImageManager>();

            services.AddScoped<IProductVariantService, ProductVariantManager>();

            services.AddScoped<ISocialService, SocialManager>();

            services.AddScoped<IWachedProductService, WachedProductManager>();

            services.AddScoped<IWishListService, WishlistManager>();

            services.AddScoped<IColorService, ColorManager>();

            services.AddScoped<ISizeService, SizeManager>();

            services.AddScoped<ISeasonEssentialService, SeasonEssentialManager>();

            return services;
        }
    }
}
