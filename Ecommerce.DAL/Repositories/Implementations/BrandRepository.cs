using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Migrations
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
