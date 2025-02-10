using BookManager.Application.Enums;
using MediatR;

namespace BookManager.Application.Commands.CreateBook
{
    public class CreateBookCommand() : IRequest<int>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public int Year { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Available;
    }
}
