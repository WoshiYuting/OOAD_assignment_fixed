using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mywebapi.Data.AddDbcontext;
using Mywebapi.Models;

namespace Mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrarainController : ControllerBase
    {
        private readonly AddDbcontext _dbcontext;

        public LibrarainController(AddDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public async Task<IActionResult> AddLibrarain(Librarian Librarains)
        {
            _dbcontext.Librarians.Add(Librarains);
            await _dbcontext.SaveChangesAsync();
            return Ok(Librarains);
        }
        [HttpGet]
        public IActionResult GetAllLibrarain()
        {
            var Librarain = _dbcontext.Librarians.ToList();
            return Ok(Librarain);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibrarainById(int id)
        {
            var Librarain = await _dbcontext.Librarians.FindAsync(id);

            if (Librarain == null)
            {
                return NotFound();
            }

            return Ok(Librarain);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLibrarain(int id, Librarian updatelibrarain)
        {
            if (id != updatelibrarain.Lid)
            {
                return BadRequest("Invalid ID");
            }

            _dbcontext.Entry(updatelibrarain).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarainExists(id))
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
        public async Task<IActionResult> DeleteLibrarain(int id)
        {
            var Librarain = await _dbcontext.Librarians.FindAsync(id);

            if (Librarain == null)
            {
                return NotFound();
            }

            _dbcontext.Librarians.Remove(Librarain);
            await _dbcontext.SaveChangesAsync();

            return Ok(Librarain);
        }
        private bool LibrarainExists(int id)
        {
            return _dbcontext.Librarians.Any(e => e.Lid == id);
        }
    }
}
