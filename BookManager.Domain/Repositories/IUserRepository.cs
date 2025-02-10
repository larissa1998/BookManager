using BookManager.Domain.Entities;

namespace BookManager.Domain.Repositories
{
    public interface IUserRepository
    {
        Task CreateUser(UserEntity user);
        Task DeleteUser(UserEntity book);
        Task<UserEntity> GetUserById(int id);
        Task<IEnumerable<UserEntity>> GetAllUser();
        Task UpdateUser(UserEntity user);
        Task<UserEntity> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
