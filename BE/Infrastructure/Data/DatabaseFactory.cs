using BE.Models.Entities;
using BE.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BE.Infrastructure.Data
{
    public class DatabaseFactory<T> : IDatabaseFactory<T> where T : BaseEntity
    {
        protected readonly EFContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        public DatabaseFactory(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> ExecuteDBStored(string storedName, params object[] parameters)
        {
            return _dbSet.FromSqlRaw(storedName, parameters);
        }
    }
}
