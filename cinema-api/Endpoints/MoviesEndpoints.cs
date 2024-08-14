using cinema_api.Data;
using cinema_api.Mapping;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace cinema_api.Endpoints
{
    public static class MoviesEndpoints
    {
        public static RouteGroupBuilder MapMoviesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("movies").WithTags("Movies Management");

            group.MapGet("/", async (CinemaContext dbContext) => 
                await dbContext.Movies.Select(movie => movie.ToDto())
                .AsNoTracking()
                .ToListAsync()
            )
                .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get all movies", 
                description: "Retrieves all movies from the database"
            ));

            group.MapGet("{id}", async (CinemaContext dbContext, int id) => 
            {
                var movie = await dbContext.Movies.FindAsync(id);
                return movie is null ? Results.NotFound() : Results.Ok(movie.ToDto());
            })
                .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get a movie by ID", 
                description: "Retrieves a movie from the database by its ID"
            ));

            group.MapGet("{id}/functions", async (CinemaContext dbContext, int id) => 
            {
                var movie = await dbContext.Movies.FindAsync(id);
                if (movie is null) return Results.NotFound();

                var functions = await dbContext.Functions
                    .Where(f => f.MovieId == id)
                    .Select(f => f.ToFunctionDetailsDto())
                    .ToListAsync();

                return Results.Ok(functions);
            })
                .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get all functions of a movie", 
                description: "Retrieves all functions of a movie from the database"
            ));

            group.MapGet("{id}/director", async (CinemaContext dbContext, int id) => 
            {
                var movie = await dbContext.Movies.FindAsync(id);
                if (movie is null) return Results.NotFound();

                var director = await dbContext.Directors
                    .Where(d => d.Id == movie.DirectorId)
                    .Select(d => d.ToDto())
                    .FirstOrDefaultAsync();

                return director is null ? Results.NotFound() : Results.Ok(director);
            })
                .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get the director of a movie", 
                description: "Retrieves the director of a movie from the database"
            ));

            return group;
        }
    }
}
