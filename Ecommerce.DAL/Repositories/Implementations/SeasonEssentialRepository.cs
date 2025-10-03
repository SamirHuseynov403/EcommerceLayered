using Ecommerce.DAL.Data;
using Ecommerce.DAL.Entities;
using Ecommerce.DAL.Repositories.Interfaces;

namespace Ecommerce.DAL.Repositories.Migrations
{
    public class SeasonEssentialRepository : Repository<SeasonEssential>, ISeasonEssentialRepository
    {
        public SeasonEssentialRepository(AppDbContext context) : base(context)
        {
        }
    }
    
}
