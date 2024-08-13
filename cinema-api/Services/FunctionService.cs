using cinema_api.Data;
using cinema_api.Dtos;
using cinema_api.Entities;
using cinema_api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace cinema_api.Services
{
    public class FunctionService
    {
        private readonly CinemaContext _dbContext;

        public FunctionService(CinemaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool Success, string ErrorMessage)> CanAddFunctionAsync(int movieId)
        {
            var movie = await _dbContext.Movies.FindAsync(movieId);
            if (movie == null)
            {
                return (false, "Movie not found.");
            }

            var existingFunctionsCount = await _dbContext.Functions
                .Include(f => f.Movie)
                .CountAsync(f => f.Movie != null && f.Movie.DirectorId == movie.DirectorId);

            if (existingFunctionsCount >= 10)
            {
                return (false, "Cannot add more than 10 functions for the same director.");
            }

            if (movie.IsInternational)
            {
                var dailyFunctionsCount = await _dbContext.Functions
                    .CountAsync(f => f.MovieId == movieId && f.Date == DateOnly.FromDateTime(DateTime.Now));

                if (dailyFunctionsCount >= 8)
                {
                    return (false, "Cannot add more than 8 functions per day for an international movie.");
                }
            }

            return (true, string.Empty);
        }

        public async Task<Function> AddFunctionAsync(CreateFunctionDto newFunction)
        {
            Function function = newFunction.ToEntity();
            _dbContext.Functions.Add(function);
            await _dbContext.SaveChangesAsync();
            return function;
        }
    }
}
