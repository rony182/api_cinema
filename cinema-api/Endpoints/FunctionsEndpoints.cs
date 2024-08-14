using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Entities;
using cinema_api.Mapping;
using cinema_api.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace cinema_api.Endpoints
{
    public static class FunctionsEndpoints
    {
        private const string GetFunctionEndpointName = "GetFunction";

        public static RouteGroupBuilder MapFunctionsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("functions").WithParameterValidation()
                .WithTags("Functions Management");

            group.MapGet("/", async (CinemaContext dbContext) =>
                await dbContext.Functions
                    .Include(function => function.Movie)
                    .Select(function => function.ToFunctionSummaryDto())
                    .AsNoTracking()
                    .ToListAsync()
            )
                .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get all functions",
                description: "Retrieves all functions from the database"
            ));

            group.MapGet("/{id}", async (int id, CinemaContext dbContext) =>
            {
                Function? function = await dbContext.Functions.FindAsync(id);

                return function is null ? Results.NotFound() : Results.Ok(function.ToFunctionDetailsDto());
            }).WithName(GetFunctionEndpointName)
            .WithMetadata(new SwaggerOperationAttribute(
                summary: "Get a function by ID",
                description: "Retrieves a function from the database by its ID"
            ));

            group.MapPost("/", async (CreateFunctionDto newFunction, CinemaContext dbContext, FunctionService functionService) =>
            {
                var (canAdd, errorMessage) = await functionService.CanAddFunctionAsync(newFunction.MovieId);
                if (!canAdd)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                Function function = newFunction.ToEntity();

                dbContext.Functions.Add(function);

                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(
                    GetFunctionEndpointName,
                    new { id = function.Id },
                    function.ToFunctionDetailsDto()
                    );
            })
                .WithMetadata(new SwaggerOperationAttribute(
                    summary: "Create a new function",
                    description: "Adds a new function to the database"
                    ));

            group.MapPut("/{id}", async (int id, UpdateFunctionDto updatedFunction, CinemaContext dbContext, FunctionService functionService) =>
            {
                var existingFunction = await dbContext.Functions.FindAsync(id);

                if (existingFunction == null) return Results.NotFound();

                var (canAdd, errorMessage) = await functionService.CanAddFunctionAsync(updatedFunction.MovieId);
                if (!canAdd)
                {
                    return Results.BadRequest(new { Error = errorMessage });
                }

                dbContext.Entry(existingFunction)
                        .CurrentValues
                        .SetValues(updatedFunction.ToEntity(id));

                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            })
                .WithMetadata(new SwaggerOperationAttribute(
                    summary: "Update a function",
                    description: "Updates an existing function in the database"
                    ));

            group.MapDelete("/{id}", async (int id, CinemaContext dbContext) =>
            {
                await dbContext.Functions.Where(function => function.Id == id).ExecuteDeleteAsync();

                return Results.NoContent();
            })
                .WithMetadata(new SwaggerOperationAttribute(
                    summary: "Delete a function",
                    description: "Removes a function from the database"
                    ));

            return group;
        }
    }
}
