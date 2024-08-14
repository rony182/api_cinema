using FluentValidation;
using FluentValidation.AspNetCore;
using cinema_api.Data;
using cinema_api.Endpoints;
using cinema_api.Dtos;
using cinema_api.Services;
using System.Text.Json;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Cinema");

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddSqlite<CinemaContext>(connString);
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateFunctionDtoValidator>();
builder.Services.AddScoped<FunctionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:3000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cinema API",
        Version = "v1",
        Description = "An API for managing cinema functions and movies"
    });

    c.AddServer(new OpenApiServer
    {
        Url = "http://localhost:5055",
        Description = "Local API Server"
    });
    
    c.EnableAnnotations();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseCors("AllowReactApp");

app.UseMiddleware<ValidationMiddleware<CreateFunctionDto>>();

app.MapDirectorsEndpoints();
app.MapFunctionsEndpoints();
app.MapMoviesEndpoints();

await app.MigrateDbAsync();

app.Run();
