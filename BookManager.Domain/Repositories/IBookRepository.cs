using BookManager.Domain.Entities;

namespace BookManager.Domain.Repositories
{
    public interface IBookRepository
    {
        Task CreateBook(BookEntity book);
        Task<IEnumerable<BookEntity>> GetAllBooks();
        Task<BookEntity> GetBookById(int id);
        Task DeleteBook(BookEntity book);
        Task UpdateBook(BookEntity book);
    }
}
