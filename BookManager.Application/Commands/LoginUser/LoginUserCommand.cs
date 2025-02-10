using BookManager.Application.Response;
using MediatR;

namespace BookManager.Application.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
