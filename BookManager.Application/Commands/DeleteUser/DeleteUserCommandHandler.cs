using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            if (user == null)
            {
                throw new Exception("Not Found");
            }

            await _userRepository.DeleteUser(user);

            return Unit.Value;
        }
    }
}
