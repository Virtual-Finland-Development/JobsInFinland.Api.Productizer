using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.Middleware;

public class AuthGwAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthGwRequestOptions _options;

    public AuthGwAuthorizationMiddleware(RequestDelegate next, AuthGwRequestOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task Invoke(HttpContext context, IAuthorizationService service)
    {
        if (_options.AllowedRequestPaths.Any(path => context.Request.Path == path))
        {
            await _next.Invoke(context);
            return;
        }

        try
        {
            await service.Authorize(context.Request);
        }
        catch (HttpRequestException e)
        {
            var statusCode = 500;
            if (e.StatusCode != null) statusCode = (int)e.StatusCode;

            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(e.Message);

            return;
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.Message);
            return;
        }

        await _next.Invoke(context);
    }
}
