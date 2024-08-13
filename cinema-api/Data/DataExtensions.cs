﻿using Microsoft.EntityFrameworkCore;

namespace cinema_api.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CinemaContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
