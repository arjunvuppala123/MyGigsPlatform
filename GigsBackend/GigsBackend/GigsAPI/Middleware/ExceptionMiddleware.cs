using System.Net;
using System.Text.Json;

namespace GigsAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    public static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = new
        {
            Message = "An unhandled exception has occurred.",
            Detail = exception.Message,
            StatusCode = (int)HttpStatusCode.InternalServerError
        };
        
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        
        var result = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(result);
    }
}