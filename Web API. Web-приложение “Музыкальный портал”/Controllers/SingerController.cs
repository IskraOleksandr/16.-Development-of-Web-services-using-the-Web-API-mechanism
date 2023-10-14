using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API._Web_приложение__Музыкальный_портал_.Models;

namespace Web_API._Web_приложение__Музыкальный_портал_.Controllers
{
    [ApiController]
    [Route("api/Singers")]
    public class SingerController : Controller
    {
        private readonly Music_Portal_APIContext _context;

        public SingerController(Music_Portal_APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Singer>>> GetSingers()
        {
            return await _context.Singers.ToListAsync();
        }

        // POST: api/Students
        [HttpPost]//add
        public async Task<ActionResult<Singer>> PostSinger(Singer singer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Singers.Add(singer);
            await _context.SaveChangesAsync();

            return Ok(singer);
        }

        // PUT: api/Students
        [HttpPut]
        public async Task<ActionResult<Singer>> PutSinger(Singer singer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Singers.Any(e => e.Id == singer.Id))
            {
                return NotFound();
            }

            _context.Update(singer);
            await _context.SaveChangesAsync();
            return Ok(singer);
        }

        // DELETE: api/Students/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Singer>> DeleteUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var singer = await _context.Singers.SingleOrDefaultAsync(m => m.Id == id);
            if (singer == null)
            {
                return NotFound();
            }

            _context.Singers.Remove(singer);
            await _context.SaveChangesAsync();

            return Ok(singer);
        }
    }
}
