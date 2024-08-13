using cinema_api.Data;
using cinema_api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cinema_api.Endpoints
{
    public static class MoviesEndpoints
    {
        public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies");

            group.MapGet("/", async (CinemaContext dbContext) => 
                await dbContext.Movies.Select(movie => movie.ToDto())
                .AsNoTracking()
                .ToListAsync()
            );

            group.MapGet("{id}", async (CinemaContext dbContext, int id) => 
            {
                var movie = await dbContext.Movies.FindAsync(id);
                return movie is null ? Results.NotFound() : Results.Ok(movie.ToDto());
            });

            return group;
        }
    }
}
