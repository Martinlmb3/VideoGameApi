using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame { Id = 1, Title = "The Legend of Zelda: Breath of the Wild", Genre = "Action-adventure", Platform = "Nintendo Switch", ReleaseDate = "March 3, 2017", Developer = "Nintendo EPD", Publisher = "Nintendo" },
            new VideoGame { Id = 2, Title = "The Witcher 3: Wild Hunt", Genre = "Action role-playing", Platform = "PC, PS4, Xbox One, Nintendo Switch", ReleaseDate = "May 19, 2015", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
            new VideoGame { Id = 3, Title = "Minecraft", Genre = "Sandbox, Survival", Platform = "PC, Console, Mobile", ReleaseDate = "November 18, 2011", Developer = "Mojang Studios", Publisher = "Mojang Studios" }
        };
        [HttpGet]
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<VideoGame> GetVideoGame(int id)
        {
            var videoGame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }

        [HttpPost]
        public ActionResult<VideoGame> AddVideoGame(VideoGame newGame)
        {
            if(newGame is null)
            {
                return BadRequest("Video game data is null.");
            }
            newGame.Id = videoGames.Max(g => g.Id) + 1;
            videoGames.Add(newGame);
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
