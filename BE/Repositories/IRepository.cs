using BE.Models.Entities;
using System.Linq.Expressions;

namespace BE.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Find(long id);
        bool Add(TEntity entity);
        bool AddRange(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression);
        bool Update(TEntity entity);
        TEntity InsertOrUpdate(TEntity entity);
        bool UpdateRange(IEnumerable<TEntity> entities);
        bool Delete(TEntity entity);
        bool DeleteRange(IEnumerable<TEntity> entities);
        bool Any(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FindAsync(long id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression);
        Task<IList<TEntity>> GetAllAsync();
    }
}
