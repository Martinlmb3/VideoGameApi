using Microsoft.EntityFrameworkCore;
using VideoGameApi;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "The Legend of Code",
                    Genre = "Adventure",
                    Platform = "PC",
                    Developer = "CodeForge Studios",
                    Publisher = "Binary Dreams",
                    Image = ""
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Pixel Racer X",
                    Genre = "Racing",
                    Platform = "Xbox",
                    Developer = "SpeedByte",
                    Publisher = "TurboSoft",
                    Image = ""
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Mystic Realms",
                    Genre = "RPG",
                    Platform = "PlayStation",
                    Developer = "DreamPixel",
                    Publisher = "EpicPlay",
                    Image = ""
                }
            );
        }
    }
}