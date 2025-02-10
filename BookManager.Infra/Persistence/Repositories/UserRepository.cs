using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookManagerDbContext _dbContext;

        public UserRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateUser(UserEntity user)
        {
            await _dbContext.User.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUser(UserEntity user)
        {
            _dbContext.User.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(UserEntity user)
        {
            _dbContext.User.Update(user);
            await _dbContext.SaveChangesAsync();

        }
        public async Task<UserEntity> GetUserById(int id)
        {
            return await _dbContext.User
                .Include(u => u.Loans)
                .SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUser()
        {
            return await _dbContext.User
                .Include(u => u.Loans)
                .ToListAsync();
        }

        public async Task<UserEntity> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext
                .User
                .SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);
        }
    }
}
