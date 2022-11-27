using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.Middleware;

public class AuthGwAuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthGwAuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IAuthorizationService service)
    {
        try
        {
            await service.Authorize(context.Request);
        }
        catch (HttpRequestException e)
        {
            var statusCode = 500;
            if (e.StatusCode != null) statusCode = (int)e.StatusCode;

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync("Could not authorize request at Authentication Gateway");
            return;
        }

        await _next.Invoke(context);
    }
}
