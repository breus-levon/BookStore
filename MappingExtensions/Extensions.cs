using BookStore.Database.Entities;
using BookStore.ViewModels;

namespace BookStore.MappingExtensions
{
    internal static class Extensions
    {
        internal static Book UpdateBookRequestAsBook(
            this UpdateBookRequest request, ref Book book)
        {
            book.AmountInStorage = request.AmountInStorage;
            book.Price = request.Price;

            return book;
        }


        internal static Book EditBookRequestAsBook(
            this EditBookRequest request, ref Book book)
        {
            book.Title = request.Title;
            book.AuthorName = request.AuthorName;
            book.Publisher = request.Publisher;
            book.YearOfPublication = request.YearOfPublication;

            return book;
        }


        internal static Author EditAuthorRequestAsAuthor(
            this EditAuthorRequest request, ref Author author)
        {
            author.Name = request.Name;

            return author;
        }
    }
}
