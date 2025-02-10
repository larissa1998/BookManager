using BookManager.Application.Response;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetById
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookResponse>
    {
        private readonly IBookRepository _bookRepository;

        public GetBookByIdQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);

            if (book == null)
            {
                throw new Exception("Book null");
            }

            var response = new BookResponse
            {
                Author = book.Author,
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                Year = book.Year,
                Status = book.Status,
            };

            return response;
        }
    }
}
