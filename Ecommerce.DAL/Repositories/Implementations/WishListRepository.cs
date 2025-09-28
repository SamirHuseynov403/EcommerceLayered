using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Migrations
{
    public class WishListRepository : Repository<WishList>, IWishListRepository
    {
        public WishListRepository(AppDbContext context) : base(context)
        {
        }
    }

}
