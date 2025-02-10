using BookManager.Domain.Entities;
using BookManager.Domain.Repositories;
using BookManager.Domain.Services;
using MediatR;

namespace BookManager.Application.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public CreateUserCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = new UserEntity(request.Name, request.Email, passwordHash, request.Role);

            await _userRepository.CreateUser(user);

            return user.Id;
        }


    }
}
