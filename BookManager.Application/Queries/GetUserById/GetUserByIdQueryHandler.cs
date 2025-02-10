using BookManager.Application.Response;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserById(request.Id);

            if (user == null)
            {
                throw new Exception("Not Found user");
            }

            var response = new UserResponse
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name
            };

            return response;
        }
    }
}
