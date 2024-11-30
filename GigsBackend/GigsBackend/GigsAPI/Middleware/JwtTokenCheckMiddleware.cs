namespace GigsAPI.Middleware;

public class JwtTokenCheckMiddleware
{
    private readonly RequestDelegate _next;

    public JwtTokenCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();

        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        {
            var token = authorizationHeader.Substring("Bearer ".Length).Trim();

            context.Items["JwtToken"] = token;
        }
        else
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized: Missing or invalid JWT token.");
            return;
        }

        await _next(context);
    }
}