using FluentValidation;
using FluentValidation.AspNetCore;
using cinema_api.Data;
using cinema_api.Endpoints;
using cinema_api.Dtos;
using cinema_api.Services;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Cinema");

builder.Services.AddSqlite<CinemaContext>(connString);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateFunctionDtoValidator>();
builder.Services.AddScoped<FunctionService>();

var app = builder.Build();

app.UseMiddleware<ValidationMiddleware<CreateFunctionDto>>();

app.MapFunctionsEndpoints();
app.MapMoviesEndpoints();
app.MapDirectorsEndpoints();

await app.MigrateDbAsync();

app.Run();