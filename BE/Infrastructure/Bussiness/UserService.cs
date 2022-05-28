using BE.Infrastructure.Contracts;
using BE.Models.Entities;
using BE.Repositories;

namespace BE.Infrastructure.Bussiness
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Adduser(User user)
        {
            await _unitOfWork.Repository<User>().AddAsync(user);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task<bool> AddUserRange(List<User> users)
        {
            await _unitOfWork.Repository<User>().AddRangeAsync(users);
            return await _unitOfWork.SaveChangeAsync();
        }

        public async Task DeleteUser(long id)
        {
            var entity = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(x => x.Id == id);
            _unitOfWork.Repository<User>().Delete(entity); 
        }

        public async Task<User> GetUser(long id)
        {
            return await _unitOfWork.Repository<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _unitOfWork.Repository<User>().GetAllAsync();
        }

        public async Task<bool> UpdateUser(User user)
        {
            var entity = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(x => x.Id == user.Id);
            if (entity == null)
            {
                return false;
            }
            entity.username = user.username;
            entity.email = user.email;
            entity.password = user.password;
            entity.numberPhone = user.numberPhone;
            
            return await _unitOfWork.SaveChangeAsync();
        }
    }
}
