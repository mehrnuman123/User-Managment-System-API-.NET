using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Diagnostics;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Log request details
        Debug.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");

        await _next(context); // Call the next middleware

        // Log response details
        Debug.WriteLine($"Response: {context.Response.StatusCode}");
    }
}
