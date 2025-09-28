using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Migrations
{
    public class WachedProductRepository : Repository<WachedProduct>, IWachedProductRepository
    {
        public WachedProductRepository(AppDbContext context) : base(context)
        {
        }
    }

}
