using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BookManager.Infra.Persistence
{
    public class BookManagerDbContext : DbContext
    {
        public BookManagerDbContext(DbContextOptions<BookManagerDbContext> options) : base(options)
        {

        }

        public DbSet<BookEntity> Book { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<LoanEntity> Loan { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
