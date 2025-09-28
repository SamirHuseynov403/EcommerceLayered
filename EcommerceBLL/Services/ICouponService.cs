using Ecommerce.BLL.DTOs.Coupon;
using Ecommerce.DAL.Entities;

namespace Ecommerce.BLL.Services
{
    public interface ICouponService : ICrudService<Coupon, CouponDto, CreateCouponDto, UpdateCouponDto> { }
}




