
using Ecommerce.DAL.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Ecommerce.BLL.Services
{
    public interface ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel>
    where TEntity : Base
    {
        Task<IEnumerable<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool AsNoTracking = false);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool AsNoTracking = false);

        Task<TViewModel?> GetByIdAsync(int id);
        Task CreateAsync(TCreateViewModel model);
        Task<bool> UpdateAsync(int id, TUpdateViewModel model);
        Task<bool> DeleteAsync(int id);
    }
}
