using cinema_api.Data;
using cinema_api.Mapping;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace cinema_api.Endpoints
{
    public static class DirectorsEndpoints
    {
        public static RouteGroupBuilder MapDirectorsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("directors").WithTags("Directors Management");

            group.MapGet("/", async (CinemaContext dbContext) => 
                await dbContext.Directors.Select(director => director.ToDto())
                .AsNoTracking()
                .ToListAsync()
            ).WithMetadata(new SwaggerOperationAttribute(
                summary: "Get all directors", 
                description: "Retrieves all directors from the database"
                ));

            group.MapGet("{id}", async (CinemaContext dbContext, int id) => 
            {
                var director = await dbContext.Directors.FindAsync(id);
                return director is null ? Results.NotFound() : Results.Ok(director.ToDto());
            }).WithMetadata(new SwaggerOperationAttribute(
                summary: "Get a director by ID", 
                description: "Retrieves a director from the database by its ID"
                ));

            return group;
        }
    }
}
