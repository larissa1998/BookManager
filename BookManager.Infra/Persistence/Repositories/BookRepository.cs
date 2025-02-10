using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Infra.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookManagerDbContext _dbContext;

        public BookRepository(BookManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateBook(BookEntity book)
        {
            await _dbContext.Book.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateBook(BookEntity book)
        {
            _dbContext.Book.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookEntity>> GetAllBooks()
        {
            return await _dbContext.Book.ToListAsync();
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            return await _dbContext.Book.SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteBook(BookEntity book)
        {
            _dbContext.Book.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
