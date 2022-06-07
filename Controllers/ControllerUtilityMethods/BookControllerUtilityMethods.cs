using AutoMapper;
using BookStore.Database.Context;
using BookStore.Database.Entities;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers.ControllerUtilityMethods
{
    internal static class BookControllerHttpPostLogic
    {
        //check if set of books already contains an identical book
        private static async Task<bool> ContainsAsync(DbSet<Book> books, Book book)
        {
            var identicalBook = await books.FirstOrDefaultAsync(x => 
            x.Title == book.Title && x.Publisher == book.Publisher && 
            x.YearOfPublication == book.YearOfPublication);

            return identicalBook != null;
        }


        //return author id, create new one if needed
        private static async Task<Guid> RegisterAuthorAsync(
            DbSet<Author> authors, Guid bookId, string authorName)
        {
            var author = await authors.FirstOrDefaultAsync(x => x.Name == authorName);

            if(author == null)
            {
                author = new Author
                {
                    Name = authorName,
                    AuthorId = new Guid(),
                    BookIds = new List<Guid>() { }
                };
                await authors.AddAsync(author);
            }
            return author.AuthorId;
        }


        //create a new Book and asign it to an author
        internal static async Task<IActionResult> AsignBookToAuthorAsync(
            AddBookRequest request, BookStoreContext context, 
            IMapper mapper, ILogger logger, ControllerBase controllerBase)
        {
            var newBook = mapper.Map<Book>(request);

            if (await ContainsAsync(context.Books, newBook))
            {
                logger.LogError("This book is already in the database.");
                return controllerBase.StatusCode(StatusCodes.Status400BadRequest);
            }

            newBook.AuthorId = await RegisterAuthorAsync(context.Authors, newBook.BookId, request.AuthorName);

            await context.Books.AddAsync(newBook);
            await context.SaveChangesAsync();

            var author = await context.Authors.FirstAsync(x => x.AuthorId == newBook.AuthorId);
            author.BookIds.Add(newBook.BookId);
            await context.SaveChangesAsync();

            logger.LogInformation("This book is added to the database saccessfully.");
            return controllerBase.StatusCode(StatusCodes.Status201Created); ;
        }
    }
}
