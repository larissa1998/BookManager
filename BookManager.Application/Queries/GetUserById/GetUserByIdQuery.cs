using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserResponse>
    {
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
