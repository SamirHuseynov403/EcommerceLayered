using Ecommerce.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DAL.Init
{
    public class DataInitializer
    {
        private readonly AppDbContext _context;

        public DataInitializer(AppDbContext context)
        {
            _context = context;
        }
        public async Task InitalizeAsync()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
