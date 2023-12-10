using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Mywebapi.Data.AddDbcontext;
using Mywebapi.Models;
using System.Linq;

namespace Mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AddDbcontext _dbcontext;
        public BookController(AddDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost("{categoryId}")]
        public async Task<IActionResult> AddBook(int categoryId, [FromBody] Book book)
        {
            // Retrieve the existing category from the database
            var existingCategory = await _dbcontext.categories.FindAsync(categoryId);

            if (existingCategory == null)
            {
                // If the category doesn't exist, return a not found response
                return NotFound($"Category with ID {categoryId} not found.");
            }

            // Assign the existing category to the book
            book.Category = existingCategory;

            // Add the book to the context and save changes
            _dbcontext.Books.Add(book);
            await _dbcontext.SaveChangesAsync();

            // Return the book in the response
            return Ok(book);
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _dbcontext.Books.Include(b => b.Category).ToList();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _dbcontext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            var books = _dbcontext.Books.Include(b => b.Category).ToList();
            return Ok(book);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book updatedBook)
        {
            if (id != updatedBook.IBook)
            {
                return BadRequest("Invalid ID");
            }

            _dbcontext.Entry(updatedBook).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _dbcontext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            _dbcontext.Books.Remove(book);
            await _dbcontext.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return _dbcontext.Books.Any(e => e.IBook == id);
        }

    }
}
