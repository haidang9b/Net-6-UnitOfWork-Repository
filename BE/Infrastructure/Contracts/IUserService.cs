using BE.Models.Entities;

namespace BE.Infrastructure.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(long id);
        Task<bool> Adduser(User user);
        Task<bool> UpdateUser(User user);
        Task DeleteUser(long id);
    }
}
