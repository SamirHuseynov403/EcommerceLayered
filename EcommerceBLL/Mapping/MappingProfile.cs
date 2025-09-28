
using AutoMapper;
using Ecommerce.BLL.DTOs.Bio;
using Ecommerce.BLL.DTOs.Brand;
using Ecommerce.BLL.DTOs.Category;
using Ecommerce.BLL.DTOs.Color;
using Ecommerce.BLL.DTOs.Coupon;
using Ecommerce.BLL.DTOs.Currency;
using Ecommerce.BLL.DTOs.Language;
using Ecommerce.BLL.DTOs.Order;
using Ecommerce.BLL.DTOs.OrderItem;
using Ecommerce.BLL.DTOs.Product;
using Ecommerce.BLL.DTOs.ProductImage;
using Ecommerce.BLL.DTOs.ProductVariant;
using Ecommerce.BLL.DTOs.Social;
using Ecommerce.BLL.DTOs.WachedProduct;
using Ecommerce.BLL.DTOs.WishList;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Bio,BioDto>().ReverseMap();
            CreateMap<Bio,CreateBioDto>().ReverseMap();
            CreateMap<Bio, UpdateBioDto>().ReverseMap();

            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<Brand, BrandCreateDto>().ReverseMap();
            CreateMap<Brand, BrandUpdateDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Coupon, CouponDto>().ReverseMap();
            CreateMap<Coupon, CreateCouponDto>().ReverseMap();
            CreateMap<Coupon, UpdateCouponDto>().ReverseMap();

            CreateMap<Currency, CurrencyDto>().ReverseMap();
            CreateMap<Currency, CreateCurrencyDto>().ReverseMap();
            CreateMap<Currency, UpdateCurrencyDto>().ReverseMap();

            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Language, CreateLanguageDto>().ReverseMap();
            CreateMap<Language, UpdateLanguageDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderDto>().ReverseMap();

            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<OrderItem, CreateOrderItemDto>().ReverseMap();
            CreateMap<OrderItem, UpdateOrderItemDto>().ReverseMap();

            CreateMap<Product, ProductDto>()
             .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
             .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
             .ForMember(dest => dest.ProductVariants, opt => opt.MapFrom(src => src.ProductVariants));
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();

            CreateMap<ProductDto, UpdateProductDto>().ReverseMap();

            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();

            CreateMap<ProductVariant, ProductVariantDto>().ReverseMap();
            CreateMap<ProductVariant, CreateProductVariantDto>().ReverseMap();
            CreateMap<ProductVariant, UpdateProductVariantDto>().ReverseMap();

            CreateMap<ProductVariantDto, UpdateProductVariantDto>().ReverseMap();


            CreateMap<Social, SocialDto>().ReverseMap();
            CreateMap<Social, CreateSocialDto>().ReverseMap();
            CreateMap<Social, UpdateSocialDto>().ReverseMap();

            CreateMap<WachedProduct, WachedProductDto>().ReverseMap();
            CreateMap<WachedProduct, CreateWachedProductDto>().ReverseMap();
            CreateMap<WachedProduct, UpdateWachedProductDto>().ReverseMap();

            CreateMap<WishList, WishListDto>().ReverseMap();
            CreateMap<WishList, CreateWishlistDto>().ReverseMap();
            CreateMap<WishList, UpdateWishlistDto>().ReverseMap();

            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<Color, CreateColorDto>().ReverseMap();
            CreateMap<Color, UpdateColorDto>().ReverseMap();

            CreateMap<Size, SizeDto>().ReverseMap();
            CreateMap<Size, CreateSizeDto>().ReverseMap();
            CreateMap<Size, UpdateSizeDto>().ReverseMap();

        }
    }
}
