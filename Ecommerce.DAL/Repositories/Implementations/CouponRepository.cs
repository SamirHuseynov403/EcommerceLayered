using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Migrations
{
    public class CouponRepository : Repository<Coupon>, ICouponRepository
    {
        public CouponRepository(AppDbContext context) : base(context)
        {
        }
    }

}
