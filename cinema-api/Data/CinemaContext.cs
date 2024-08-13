using cinema_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace cinema_api.Data
{
    public class CinemaContext(DbContextOptions<CinemaContext> options) 
        : DbContext(options)
    {
        public DbSet<Function> Functions => Set<Function>();
        public DbSet<Director> Directors => Set<Director>();
        public DbSet<Movie> Movies => Set<Movie>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Director>().HasData(
                new { Id = 1, Name = "Fernando Meirelles" },
                new { Id = 2, Name = "José Padilha" },
                new { Id = 3, Name = "Walter Salles" },
                new { Id = 4, Name = "Cao Hamburger" },
                new { Id = 5, Name = "Héctor Babenco" },
                new { Id = 6, Name = "Christopher Nolan" },
                new { Id = 7, Name = "Steven Spielberg" },
                new { Id = 8, Name = "Martin Scorsese" },
                new { Id = 9, Name = "Quentin Tarantino" },
                new { Id = 10, Name = "David Fincher" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new { Id = 1, Title = "City of God", DirectorId = 1, IsInternational = false },
                new { Id = 2, Title = "Elite Squad", DirectorId = 2, IsInternational = false },
                new { Id = 3, Title = "Central Station", DirectorId = 3, IsInternational = false },
                new { Id = 4, Title = "The Year My Parents Went on Vacation", DirectorId = 4, IsInternational = false },
                new { Id = 5, Title = "Carandiru", DirectorId = 5, IsInternational = false },
                new { Id = 6, Title = "Inception", DirectorId = 6, IsInternational = true },
                new { Id = 7, Title = "E.T. the Extra-Terrestrial", DirectorId = 7, IsInternational = true },
                new { Id = 8, Title = "Goodfellas", DirectorId = 8, IsInternational = true },
                new { Id = 9, Title = "Pulp Fiction", DirectorId = 9, IsInternational = true },
                new { Id = 10, Title = "Fight Club", DirectorId = 10, IsInternational = true },
                new { Id = 11, Title = "The Grand Budapest Hotel", DirectorId = 6, IsInternational = true },
                new { Id = 12, Title = "2001: A Space Odyssey", DirectorId = 7, IsInternational = true },
                new { Id = 13, Title = "Psycho", DirectorId = 8, IsInternational = true },
                new { Id = 14, Title = "The Godfather", DirectorId = 9, IsInternational = true },
                new { Id = 15, Title = "The Good, the Bad and the Ugly", DirectorId = 10, IsInternational = true }
            );
        }
    }
}
