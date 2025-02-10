using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new BookEntity(request.Title, request.Author, request.Isbn, request.Year, request.Status);

            await _bookRepository.CreateBook(book);

            return book.Id;
        }
    }
}
