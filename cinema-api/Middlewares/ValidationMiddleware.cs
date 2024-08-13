using FluentValidation;
using System.Text.Json;

public class ValidationMiddleware<T> where T : class
{
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IValidator<T> validator)
    {
        if (context.Request.Method == HttpMethods.Post || context.Request.Method == HttpMethods.Put)
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            var model = JsonSerializer.Deserialize<T>(body);

            if (model == null)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Invalid request body.");
                return;
            }

            var validationResult = await validator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(validationResult.Errors);
                return;
            }

            context.Request.Body.Position = 0;
        }

        await _next(context);
    }
}