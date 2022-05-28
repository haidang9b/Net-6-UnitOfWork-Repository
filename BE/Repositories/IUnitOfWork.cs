using BE.Models.Entities;

namespace BE.Repositories
{
    public interface IUnitOfWork
    {
        bool SaveChange();
        Task<bool> SaveChangeAsync();
        void BeginTransaction();
        void Commit();
        void RollBack();
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    }
}
