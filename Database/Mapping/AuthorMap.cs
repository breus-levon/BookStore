using BookStore.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Database.Mapping
{
    public class AuthorMap : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.Property(x => x.AuthorId).HasColumnName("Id").HasColumnType("uuid");
            builder.Property(x => x.Name).HasColumnName("Name").HasColumnType("text");
        }
    }
}
