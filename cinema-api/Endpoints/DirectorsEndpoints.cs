using cinema_api.Data;
using cinema_api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cinema_api.Endpoints
{
    public static class DirectorsEndpoints
    {
        public static RouteGroupBuilder MapDirectorsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("directors");

            group.MapGet("/", async (CinemaContext dbContext) => 
                await dbContext.Directors.Select(director => director.ToDto())
                .AsNoTracking()
                .ToListAsync()
            );

            group.MapGet("{id}", async (CinemaContext dbContext, int id) => 
            {
                var director = await dbContext.Directors.FindAsync(id);
                return director is null ? Results.NotFound() : Results.Ok(director.ToDto());
            });

            return group;
        }
    }
}
