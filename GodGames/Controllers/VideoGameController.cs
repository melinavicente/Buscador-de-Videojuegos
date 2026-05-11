using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodGames.Data;
using GodGames.Models;

namespace GodGames.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoGameController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VideoGameController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/VideoGame
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGames>>> GetAll()
        {
            return await _context.VideoGames
                .Include(v => v.Imagenes)
                .ToListAsync();
        }

        // GET: api/VideoGame/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGames>> GetVideoGame(int id)
        {
            var game = await _context.VideoGames
                .Include(v => v.Imagenes)
                .FirstOrDefaultAsync(v => v.Id == id);

            if (game == null)
                return NotFound();

            return game;
        }

        // POST: api/VideoGame
        [HttpPost]
        public async Task<ActionResult<VideoGames>> PostVideoGame(VideoGames videoGames)
        {
            _context.VideoGames.Add(videoGames);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVideoGame), new { id = videoGames.Id }, videoGames);
        }

        // PUT: api/VideoGame/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVideoGame(int id, VideoGames videoGames)
        {
            if (id != videoGames.Id)
                return BadRequest();

            _context.Entry(videoGames).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.VideoGames.Any(e => e.Id == id))
                    return NotFound();
                throw;
            }

            return NoContent();
        }

        // DELETE: api/VideoGame/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);

            if (game == null)
                return NotFound();

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}