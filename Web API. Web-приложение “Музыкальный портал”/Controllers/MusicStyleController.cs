using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API._Web_приложение__Музыкальный_портал_.Models;

namespace Web_API._Web_приложение__Музыкальный_портал_.Controllers
{
    [ApiController]
    [Route("api/MusicStyles")]
    public class MusicStyleController : Controller
    {
        private readonly Music_Portal_APIContext _context;

        public MusicStyleController(Music_Portal_APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicStyle>>> GetMusicStyles()
        {
            return await _context.MusicStyles.ToListAsync();
        }

        // POST: api/Students
        [HttpPost]//add
        public async Task<ActionResult<MusicStyle>> PostMusicStyle(MusicStyle style)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MusicStyles.Add(style);
            await _context.SaveChangesAsync();

            return Ok(style);
        }

        // PUT: api/Students
        [HttpPut]
        public async Task<ActionResult<MusicStyle>> PutMusicStyle(MusicStyle style)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.MusicStyles.Any(e => e.Id == style.Id))
            {
                return NotFound();
            }

            _context.Update(style);
            await _context.SaveChangesAsync();
            return Ok(style);
        }

        // DELETE: api/Students/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusicStyle>> DeleteMusicStyle(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var style = await _context.MusicStyles.SingleOrDefaultAsync(m => m.Id == id);
            if (style == null)
            {
                return NotFound();
            }

            _context.MusicStyles.Remove(style);
            await _context.SaveChangesAsync();

            return Ok(style);
        }
    }
}
