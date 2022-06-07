using BookStore.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Database.Mapping
{
    public class BookMap : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.Property(x => x.BookId).HasColumnName("Id").HasColumnType("uuid");
            builder.Property(x => x.Title).HasColumnName("Title").HasColumnType("text");
            builder.Property(x => x.Publisher).HasColumnName("Publisher").HasColumnType("text");
            builder.Property(x => x.AuthorName).HasColumnName("AuthorName").HasColumnType("text");
            builder.Property(x => x.YearOfPublication).HasColumnName("YearOfPublication").HasColumnType("int4");
            builder.Property(x => x.AmountInStorage).HasColumnName("AmountInStorage").HasColumnType("int4");
            builder.Property(x => x.Price).HasColumnName("Price").HasColumnType("numeric");
            builder.Property(x => x.AuthorId).HasColumnName("AuthorId").HasColumnType("uuid");
        }
    }
}
