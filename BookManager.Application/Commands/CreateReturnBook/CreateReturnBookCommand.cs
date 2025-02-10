using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Commands.CreateReturnBook
{
    public class CreateReturnBookCommand : IRequest<ReturnBookResponse>
    {
        public int UserId { get; set; }
        public int BookId { get; set; }
    }
}
