using BE.Models.Entities;

namespace BE.Repositories
{
    public interface IDatabaseFactory<T> where T : BaseEntity
    {
        IQueryable<T> ExecuteDBStored(string storedName, params object[] parameters);
    }
}
