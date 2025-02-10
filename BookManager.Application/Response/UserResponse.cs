using BookManager.Domain.Entities;

namespace BookManager.Application.Response
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
