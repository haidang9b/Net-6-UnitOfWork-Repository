using BE.Models.Entities;
using BE.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BE.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly EFContext _dbContext;
        protected DbSet<TEntity> _dbSet => _dbContext.Set<TEntity>();

        public Repository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public bool AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public bool Any(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Any(expression);
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public bool DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            return _dbContext.SaveChanges() > 0;
        }

        public TEntity Find(long id)
        {
            return _dbSet.Find(id);
        }

        public async Task<TEntity> FindAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.FirstOrDefaultAsync(expression);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbSet.Where(expression).ToListAsync();
        }

        public bool Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }

        public bool UpdateRange(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
            return _dbContext.SaveChanges() > 0;
        }

        public TEntity InsertOrUpdate(TEntity entity)
        {
            var result = _dbSet.Attach(entity);
            _dbContext.SaveChanges();
            return result.Entity;
        }
    }
}
