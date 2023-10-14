using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Web_API._Web_приложение__Музыкальный_портал_.Models;

namespace Web_API._Web_приложение__Музыкальный_портал_.Controllers
{
    [ApiController]
    [Route("api/Musics")]
    public class MusicController : Controller
    {
        private readonly Music_Portal_APIContext _context;

        private readonly IWebHostEnvironment _appEnvironment;

        public MusicController(Music_Portal_APIContext context, IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Music>>> GetMusic()
        {
            return await _context.Musics.ToListAsync();
        }

        // POST: api/Students
        [HttpPost]//add
        public async Task<ActionResult<Music>> PostMusic(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return Ok(music);
        }

        // PUT: api/Students
        [HttpPut]
        public async Task<ActionResult<Music>> PutMusic(Music music)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_context.Musics.Any(e => e.Id == music.Id))
            {
                return NotFound();
            }

            _context.Update(music);
            await _context.SaveChangesAsync();
            return Ok(music);
        }

        // DELETE: api/Students/3
        [HttpDelete("{id}")]
        public async Task<ActionResult<Music>> DeleteMusic(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var music = await _context.Musics.SingleOrDefaultAsync(m => m.Id == id);
            if (music == null)
            {
                return NotFound();
            }

            _context.Musics.Remove(music);
            await _context.SaveChangesAsync();

            return Ok(music);
        }
    }
}