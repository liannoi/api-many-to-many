using ManyToMany.System.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.System.Infrastructure.Persistence.Configurations
{
    public class BooksAuthorsConfiguration : IEntityTypeConfiguration<BooksAuthors>
    {
        public void Configure(EntityTypeBuilder<BooksAuthors> builder)
        {
            builder.HasKey(e => new {e.AuthorId, e.BookId});

            builder.HasOne(d => d.Author)
                .WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksAuthors_AuthorId");

            builder.HasOne(d => d.Book)
                .WithMany(p => p.BooksAuthors)
                .HasForeignKey(d => d.BookId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BooksAuthors_BookId");
        }
    }
}