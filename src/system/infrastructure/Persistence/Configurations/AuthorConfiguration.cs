using ManyToMany.System.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.System.Infrastructure.Persistence.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Authors>
    {
        public void Configure(EntityTypeBuilder<Authors> builder)
        {
            builder.HasKey(e => e.AuthorId);
            builder.Property(e => e.AuthorLastName).IsRequired().HasMaxLength(128);
            builder.Property(e => e.AuthorName).IsRequired().HasMaxLength(128);
        }
    }
}