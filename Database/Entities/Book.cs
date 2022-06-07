using System;

namespace BookStore.Database.Entities
{
    public class Book
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string Publisher { get; set; }
        public int YearOfPublication { get; set; }
        public int AmountInStorage { get; set;}
        public decimal Price { get; set; }
        public Guid AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
