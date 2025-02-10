using MediatR;

namespace BookManager.Application.Commands.DeleteBook
{
    public class DeleteBookByIdCommand : IRequest<Unit>
    {
        public DeleteBookByIdCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
