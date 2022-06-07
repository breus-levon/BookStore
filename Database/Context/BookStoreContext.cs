using BookStore.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Database.Context
{
    public class BookStoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookStoreContext(DbContextOptions<BookStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //set indexes for entities
            modelBuilder.Entity<Author>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Book>().HasIndex(x => x.Title);

            //enable mapping entity - database recording
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookStoreContext).Assembly);

            modelBuilder.HasDefaultSchema(Startup.schemaName);

            modelBuilder.Entity<Author>()
                .HasMany(c => c.Books)
                .WithOne(e => e.Author)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
