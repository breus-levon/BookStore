using AutoMapper;
using BookStore.Controllers.ControllerUtilityMethods;
using BookStore.Database.Context;
using BookStore.Database.Entities;
using BookStore.MappingExtensions;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("Books")]
    public class BookStoreController : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<BookStoreController> _logger;

        public BookStoreController(BookStoreContext context,
            IMapper mapper, ILogger<BookStoreController> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;

        }


        //get all the books
        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            return await ControllerCrudLogic.GetBooksAsync(this, _context, _mapper, _logger);

            //var ListOfBooksIsEmpty = !await _context.Books.AnyAsync();
            //if (ListOfBooksIsEmpty)
            //{
            //    _logger.LogInformation("No books in database yet.");
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}
            //var fetchedListOfBooks = _context.Books
            //    .Select(x => _mapper.Map<GetBooksRequest>(x));

            //_logger.LogInformation("books are fetched successfully from database.");
            //return StatusCode(StatusCodes.Status200OK, fetchedListOfBooks);
        }


        //get books by given title
        [HttpGet("FetchByTitle")]
        public async Task<IActionResult> GetBooksByTitleAsync(string bookTitle)
        {
            return await ControllerCrudLogic.GetBooksByTitleAsync(
                bookTitle, this, _context, _mapper, _logger);

            //if (!await _context.Books.AnyAsync(x => x.Title == bookTitle))
            //{
            //    _logger.LogInformation("No books with this title.");
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}

            //var booksFetchedByTitle = _context.Books
            //    .Where(x => x.Title == bookTitle)
            //    .Select(x => _mapper.Map<GetBooksRequest>(x));

            //_logger.LogInformation("There are some books with this title.");
            //return StatusCode(StatusCodes.Status200OK, booksFetchedByTitle); 
        }


        //get books by author
        [HttpGet("FetchByAuthor")]
        public async Task<IActionResult> GetBooksByAuthorAsync(string authorName)
        {
            return await ControllerCrudLogic.GetBooksByAuthorAsync(
                authorName, this, _context, _mapper, _logger);

            //var author = await _context.Authors.FirstOrDefaultAsync(x => x.Name == authorName);
            //if (author == null)
            //{
            //    _logger.LogInformation("No books of this author.");
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}

            //var booksFetchedByAuthor = _context.Books
            //    .Where(x => x.AuthorId == author.AuthorId)
            //    .Select(x => _mapper.Map<GetBooksRequest>(x));


            //return StatusCode(StatusCodes.Status200OK, booksFetchedByAuthor);
        }


        //add a book, add an author if its his first book
        [HttpPost]
        public async Task<IActionResult> AddBookAsync(AddBookRequest request)
        {            
            return await BookControllerHttpPostLogic
                .AsignBookToAuthorAsync(request, _context, _mapper, _logger, this);
        }


        //update a book data(price, amount in storage)
        [HttpPut("UpdateBook")]
        public async Task<IActionResult> UpdateBookAsync(Guid Id, UpdateBookRequest request)
        {
            return await ControllerCrudLogic.UpdateBookAsync(
                Id, request, this, _context, _logger);

            //var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);

            //if (fetchedBook == null)
            //{
            //    _logger.LogError("A book with the id {0} isn't found.", Id);
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            //fetchedBook = request.UpdateBookRequestAsBook(ref fetchedBook);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation("Book with the id {0} is updated.", Id);

            //return StatusCode(StatusCodes.Status204NoContent);
        }


        //edit book entity
        [HttpPut("EditBook")]
        public async Task<IActionResult> EditBookAsync(Guid Id, EditBookRequest request)
        {
            return await ControllerCrudLogic.EditBookAsync(
                Id, request, this, _context, _logger);

            //var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            //if (fetchedBook == null)
            //{
            //    _logger.LogError("A book with the id {0} isn't found.", Id);
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            //fetchedBook = request.EditBookRequestAsBook(ref fetchedBook);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation(
            //    "Information about the book with the id {0} is edited.", Id);

            //return StatusCode(StatusCodes.Status204NoContent);
        }


        //edit author entity
        [HttpPut("EditAuthor")]
        public async Task<IActionResult> EditAuthorAsync(Guid Id, EditAuthorRequest request)
        {
            return await ControllerCrudLogic.EditAuthorAsync(
                Id, request, this, _context, _logger);

            //var fetchedAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
            //if (fetchedAuthor == null)
            //{
            //    _logger.LogError("An author with the id {0} isn't found.", Id);
            //    return StatusCode(StatusCodes.Status404NotFound);
            //}

            //fetchedAuthor = request.EditAuthorRequestAsAuthor(ref fetchedAuthor);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation(
            //    "Information about the author with the id {0} is edited.", Id);

            //return StatusCode(StatusCodes.Status204NoContent);
        }


        //delete a book
        [HttpDelete]
        public async Task<IActionResult> DeleteBookAsync(Guid Id)
        {
            return await ControllerCrudLogic.DeleteBookAsync(
                Id, this, _context, _logger);

            //var fetchedBook = await _context.Books.FirstOrDefaultAsync(x => x.BookId == Id);
            //if (fetchedBook == null)
            //{
            //    _logger.LogInformation(
            //        "A book with the id {0} is already deleted or it was not added.", Id);
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}

            //var author = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == fetchedBook.AuthorId);
            //if(author != null)
            //{
            //    author.BookIds.Remove(fetchedBook.BookId);
            //}

            //_context.Books.Remove(fetchedBook);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation("A book with the id {0} is deleted.", Id);

            //return StatusCode(StatusCodes.Status204NoContent);
        }


        //delete an author from database with all its books
        [HttpDelete("DeleteAuthor")]
        public async Task<IActionResult> DeleteAuthorAsync(Guid Id)
        {
            return await ControllerCrudLogic.DeleteAuthorAsync(
                Id, this, _context, _logger);

            //var fetchedAuthor = await _context.Authors.FirstOrDefaultAsync(x => x.AuthorId == Id);
            //if (fetchedAuthor == null)
            //{
            //    _logger.LogError(
            //        "An author with the id {0} is already deleted or it was not added.", Id);
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}

            //_context.Authors.Remove(fetchedAuthor);
            //await _context.SaveChangesAsync();
            //_logger.LogInformation("An author with the id {0} is deleted.", Id);

            //return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
