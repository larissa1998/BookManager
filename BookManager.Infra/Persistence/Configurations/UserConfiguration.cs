using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .HasKey(u => u.Id);

            builder
                .HasMany(u => u.Loans)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Property(e => e.Name)
                .IsRequired();

            builder
              .Property(e => e.Email)
              .IsRequired();
        }
    }
}
