using BE.Models.Entities;
using BE.Repositories;

namespace BE.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private EFContext _dbContext;
        private Dictionary<Type, object> repositories;
        public UnitOfWork(EFContext dbContext)
        {
            _dbContext = dbContext;
            repositories = new Dictionary<Type, object>();
        }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories.Add(type, new Repository<TEntity>(_dbContext));
            }
            return (IRepository<TEntity>)repositories[type];
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }

        public bool SaveChange()
        {
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
