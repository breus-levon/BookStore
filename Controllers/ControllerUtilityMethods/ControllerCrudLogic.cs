using AutoMapper;
using BookStore.Database.Context;
using BookStore.MappingExtensions;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers.ControllerUtilityMethods
{
    internal static class ControllerCrudLogic
    {
        public static async Task<IActionResult> GetBooksAsync(
            ControllerBase controllerBase, BookStoreContext _context, 
            IMapper _mapper, ILogger<BookStoreController> _logger)
        {
            var ListOfBooksIsEmpty = !await _context.Books.AnyAsync();
            if (ListOfBooksIsEmpty)
            {
                _logger.LogInformation("No books in database yet.");
                return controllerBase.StatusCode(StatusCodes.Status204NoContent);
            }
            var fetchedListOfBooks = _context.Books
                .Select(x => _mapper.Map<GetBooksRequest>(x));

            _logger.LogInformation("books are fetched successfully from database.");
            return controllerBase.StatusCode(StatusCodes.Status200OK, fetchedListOfBooks);
        }


        public static async Task<IActionResult> GetBooksByTitleAsync(string bookTitle, 
            ControllerBase controllerBase, BookStoreContext _context,
            IMapper _mapper, ILogger<BookStoreController> _logger)
        {
            if (!await _context.Books.AnyAsync(x => x.Title == bookTitle))
            {
                _logger.LogInformation("No books with this title.");
                return controllerBase.StatusCode(StatusCodes.Status204NoContent);
            }

            var booksFetchedByTitle = _context.Books
                .Where(x => x.Title == bookTitle)
                .Select(x => _mapper.Map<GetBooksRequest>(x));

            _logger.LogInformation("There are some books with this title.");
            return controllerBase.StatusCode(StatusCodes.Status200OK, booksFetchedByTitle); ;
        }


        public static async Task<IActionResult> GetBooksByAuthorAsync(string authorName,
            ControllerBase controllerBase, BookStoreContext _context,
            IMapper _mapper, ILogger<BookStoreController> _logger)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
            if (author == null)
            {
                _logger.LogInformation("No books of this author.");
                return controllerBase.StatusCode(StatusCodes.Status204NoContent);
            }

            var booksFetchedByAuthor = _context.Books
                .Where(x => x.AuthorId == author.AuthorId)
                .Select(x => _mapper.Map<GetBooksRequest>(x));


            return controllerBase.StatusCode(StatusCodes.Status200OK, booksFetchedByAuthor); ;
        }


        public static async Task<IActionResult> UpdateBookAsync(Guid Id, 
            UpdateBookRequest request, ControllerBase controllerBase, 
            BookStoreContext _context, ILogger<BookStoreController> _logger)
        {
            var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);

            if (fetchedBook == null)
            {
                _logger.LogError("A book with the id {0} isn't found.", Id);
                return controllerBase.StatusCode(StatusCodes.Status404NotFound);
            }

            fetchedBook = request.UpdateBookRequestAsBook(ref fetchedBook);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Book with the id {0} is updated.", Id);

            return controllerBase.StatusCode(StatusCodes.Status204NoContent);
        }


        public static async Task<IActionResult> EditBookAsync(Guid Id, 
            EditBookRequest request, ControllerBase controllerBase,
            BookStoreContext _context, ILogger<BookStoreController> _logger)
        {
            var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            if (fetchedBook == null)
            {
                _logger.LogError("A book with the id {0} isn't found.", Id);
                return controllerBase.StatusCode(StatusCodes.Status404NotFound);
            }

            fetchedBook = request.EditBookRequestAsBook(ref fetchedBook);
            await _context.SaveChangesAsync();
            _logger.LogInformation(
                "Information about the book with the id {0} is edited.", Id);

            return controllerBase.StatusCode(StatusCodes.Status204NoContent);
        }


        public static async Task<IActionResult> EditAuthorAsync(Guid Id, 
            EditAuthorRequest request, ControllerBase controllerBase,
            BookStoreContext _context, ILogger<BookStoreController> _logger)
        {
            var fetchedAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
            if (fetchedAuthor == null)
            {
                _logger.LogError("An author with the id {0} isn't found.", Id);
                return controllerBase.StatusCode(StatusCodes.Status404NotFound);
            }

            fetchedAuthor = request.EditAuthorRequestAsAuthor(ref fetchedAuthor);
            await _context.SaveChangesAsync();
            _logger.LogInformation(
                "Information about the author with the id {0} is edited.", Id);

            return controllerBase.StatusCode(StatusCodes.Status204NoContent);
        }


        public static async Task<IActionResult> DeleteBookAsync(
            Guid Id, ControllerBase controllerBase,
            BookStoreContext _context, ILogger<BookStoreController> _logger)
        {
            var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            if (fetchedBook == null)
            {
                _logger.LogInformation(
                    "A book with the id {0} is already deleted or it was not added.", Id);
                return controllerBase.StatusCode(StatusCodes.Status204NoContent);
            }

            var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == fetchedBook.AuthorId);
            if (author != null)
            {
                author.BookIds.Remove(fetchedBook.BookId);
            }

            _context.Books.Remove(fetchedBook);
            await _context.SaveChangesAsync();
            _logger.LogInformation("A book with the id {0} is deleted.", Id);

            return controllerBase.StatusCode(StatusCodes.Status204NoContent);
        }


        public static async Task<IActionResult> DeleteAuthorAsync(
            Guid Id, ControllerBase controllerBase,
            BookStoreContext _context, ILogger<BookStoreController> _logger)
        {
            var fetchedAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
            if (fetchedAuthor == null)
            {
                _logger.LogError(
                    "An author with the id {0} is already deleted or it was not added.", Id);
                return controllerBase.StatusCode(StatusCodes.Status204NoContent);
            }

            _context.Authors.Remove(fetchedAuthor);
            await _context.SaveChangesAsync();
            _logger.LogInformation("An author with the id {0} is deleted.", Id);

            return controllerBase.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
