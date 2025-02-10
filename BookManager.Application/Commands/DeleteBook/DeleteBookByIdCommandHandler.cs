using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Commands.DeleteBook
{
    public class DeleteBookByIdCommandHandler : IRequestHandler<DeleteBookByIdCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookByIdCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Unit> Handle(DeleteBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookById(request.Id);

            if (book == null)
            {
                throw new Exception("Not Found");
            }

            await _bookRepository.DeleteBook(book);

            return Unit.Value;
        }
    }
}
