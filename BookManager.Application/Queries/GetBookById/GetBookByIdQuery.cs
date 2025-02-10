using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Queries.GetById
{
    public class GetBookByIdQuery : IRequest<BookResponse>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
