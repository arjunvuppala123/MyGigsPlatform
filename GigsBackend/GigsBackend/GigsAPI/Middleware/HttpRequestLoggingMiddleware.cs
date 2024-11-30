using Serilog;

namespace GigsAPI.Middleware;

public class HttpRequestLoggingMiddleware
{
    private readonly RequestDelegate _next;

    public HttpRequestLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var useragent = context.Request.Headers["User-Agent"].ToString();
        var requestPath = context.Request.Path.ToString();
        
        Log.Information("Request received: {0} {1} from {2}", context.Request.Method, requestPath, useragent);

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error("ex", "An Exception occured while processing {Path}", requestPath);
            throw;
        }
    }
}

public static class SerilogRequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseHttpRequestLogging(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HttpRequestLoggingMiddleware>();
    }
}