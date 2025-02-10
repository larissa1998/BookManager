using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Queries.GetAllUser
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserResponse>>
    {
    }
}
