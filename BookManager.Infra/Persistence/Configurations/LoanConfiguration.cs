using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Configurations
{
    public class LoanConfiguration : IEntityTypeConfiguration<LoanEntity>
    {
        public void Configure(EntityTypeBuilder<LoanEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                  .HasOne<UserEntity>()
                  .WithMany(u => u.Loans)
                  .HasForeignKey(e => e.UserId)
                  .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne<BookEntity>()
              .WithMany()
              .HasForeignKey(e => e.BookId)
              .OnDelete(DeleteBehavior.Cascade);

            builder
               .Property(e => e.LoanDate)
               .IsRequired();

            builder
               .Property(e => e.UserId)
               .IsRequired();

            builder
               .Property(e => e.BookId)
               .IsRequired();

            builder
                .Property(e => e.ReturnDate)
                .IsRequired();
        }
    }
}
