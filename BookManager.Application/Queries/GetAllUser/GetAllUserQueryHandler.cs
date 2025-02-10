using BookManager.Application.Response;
using BookManager.Domain.Repositories;
using MediatR;

namespace BookManager.Application.Queries.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserResponse>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllUser();

            if (users == null)
            {
                throw new Exception("Not found users");
            }

            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Email = u.Email,
                Loans = u.Loans,
                Name = u.Name,
            }).ToList();
        }
    }
}
