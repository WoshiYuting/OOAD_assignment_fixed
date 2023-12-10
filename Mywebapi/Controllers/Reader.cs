using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mywebapi.Data.AddDbcontext;
using Mywebapi.Models;

namespace Mywebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly AddDbcontext _dbcontext;
        public ReaderController(AddDbcontext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public async Task<IActionResult> AddReader(Reader Readers)
        {
            _dbcontext.Readers.Add(Readers);
            await _dbcontext.SaveChangesAsync();
            return Ok(Readers);
        }
        [HttpGet]
        public IActionResult GetAllReader()
        {
            var Reader = _dbcontext.Readers.ToList();
            return Ok(Reader);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReaderById(int id)
        {
            var Reader = await _dbcontext.Readers.FindAsync(id);

            if (Reader == null)
            {
                return NotFound();
            }

            return Ok(Reader);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReader(int id, Reader updateReader)
        {
            if (id != updateReader.Rid)
            {
                return BadRequest("Invalid ID");
            }

            _dbcontext.Entry(updateReader).State = EntityState.Modified;

            try
            {
                await _dbcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReaderExists(id))
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
        public async Task<IActionResult> DeleteReader(int id)
        {
            var Reader = await _dbcontext.Readers.FindAsync(id);

            if (Reader == null)
            {
                return NotFound();
            }

            _dbcontext.Readers.Remove(Reader);
            await _dbcontext.SaveChangesAsync();

            return Ok(Reader);
        }
        private bool ReaderExists(int id)
        {
            return _dbcontext.Readers.Any(e => e.Rid == id);
        }
    }
}
