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
        string token = null;

        // Check the Authorization header for a Bearer token
        var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
        if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
        {
            token = authorizationHeader.Substring("Bearer ".Length).Trim();
        }

        // If no token is found in the Authorization header, check the query parameters
        if (string.IsNullOrEmpty(token))
        {
            token = context.Request.Query["access_token"].FirstOrDefault();
        }

        // If no token is found, return Unauthorized
        if (string.IsNullOrEmpty(token))
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("Unauthorized: Missing or invalid JWT token.");
            return;
        }

        // Store the token in the HttpContext for downstream processing
        context.Items["JwtToken"] = token;

        // Proceed to the next middleware
        await _next(context);
    }
}