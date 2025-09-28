using AutoMapper;
using Ecommerce.BLL.DTOs.Coupon;
using Ecommerce.BLL.Services;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.BLL.Manager
{
    public class CouponManager : CrudManager<Coupon, CouponDto, CreateCouponDto, UpdateCouponDto>, ICouponService
    {
        public CouponManager(IRepository<Coupon> respository, IMapper mapper) : base(respository, mapper)
        {
        }

    }
}
