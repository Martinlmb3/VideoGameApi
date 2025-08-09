using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        private readonly VideoGameDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }
        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<VideoGame>> GetVideoGame(int id)
        {
            var videoGame = await _context.VideoGames.FindAsync(id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }

        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if(newGame is null)
            {
                return BadRequest("Video game data is null.");
            }
            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGame), new { id = newGame.Id }, newGame);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateVideoGame(int id, VideoGame updatedGame)
        {
            if (updatedGame is null)
            {
                return BadRequest("Video game data is null.");
            }
            var existingGame = videoGames.FirstOrDefault(v => v.Id == id);
            if (existingGame == null)
            {
                return NotFound();
            }
            existingGame.Title = updatedGame.Title;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Platform = updatedGame.Platform;
            existingGame.ReleaseDate = updatedGame.ReleaseDate;
            existingGame.Developer = updatedGame.Developer;
            existingGame.Publisher = updatedGame.Publisher;
            existingGame.Image = updatedGame.Image;
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVideoGame(int id)
        {
            var videoGame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            videoGames.Remove(videoGame);
            return NoContent();
        }
    }
}
