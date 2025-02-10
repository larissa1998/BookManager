using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<IEnumerable<BookResponse>>
    {
    }
}
