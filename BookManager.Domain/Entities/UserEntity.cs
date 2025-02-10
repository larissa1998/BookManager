using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Domain.Entities
{
    public class UserEntity
    {
        public UserEntity(string name, string email, string password, string role)
        {
            Name = name;
            Email = email;
            Password = password;
            Role = role;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public List<LoanEntity> Loans { get; set; } = new List<LoanEntity>();
    }
}
