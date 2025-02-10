using BookManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookManager.Infra.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
               .Property(e => e.Isbn)
               .IsRequired();

            builder
                .Property(e => e.Year)
                .IsRequired();

            builder
               .Property(e => e.Title)
               .IsRequired();

            builder
                .Property(e => e.Author)
                .IsRequired();

            builder
             .Property(e => e.Status)
             .IsRequired();
        }
    }
}
