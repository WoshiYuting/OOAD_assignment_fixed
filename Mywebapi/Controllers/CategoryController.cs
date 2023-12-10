using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mywebapi.Data.AddDbcontext;
using Mywebapi.Models;

namespace Mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AddDbcontext _dbcontext;
        public CategoryController(AddDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(Category categories)
        {
            _dbcontext.categories.Add(categories);
            await _dbcontext.SaveChangesAsync();
            return Ok(categories);
        }
        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var categories = _dbcontext.categories.ToList();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _dbcontext.categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Category updatecategories)
        {
            if (id != updatecategories.CategoryId)
            {
                return BadRequest("Invalid ID");
            }

            _dbcontext.Entry(updatecategories).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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
        public async Task<IActionResult> DeleteCategroy(int id)
        {
            var category = await _dbcontext.categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            _dbcontext.categories.Remove(category);
            await _dbcontext.SaveChangesAsync();

            return Ok(category);
        }
        private bool CategoryExists(int id)
        {
            return _dbcontext.categories.Any(e => e.CategoryId == id);
        }
    }
}
