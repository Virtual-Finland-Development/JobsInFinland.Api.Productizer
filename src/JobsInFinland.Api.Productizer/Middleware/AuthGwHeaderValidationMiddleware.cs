using System.Net;

namespace JobsInFinland.Api.Productizer.Middleware;

public class AuthGwHeaderValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly AuthGwRequestOptions _options;

    public AuthGwHeaderValidationMiddleware(RequestDelegate next, AuthGwRequestOptions options)
    {
        _next = next;
        _options = options;
    }

    public async Task Invoke(HttpContext context)
    {
        // Skip allowed paths
        if (_options.AllowedRequestPaths.Any(path => context.Request.Path == path))
        {
            await _next.Invoke(context);
            return;
        }

        var originHeaders =
            context.Request.Headers.ToDictionary(
                x => x.Key.ToLowerInvariant(),
                x => x.Value.ToString());

        if (_options.RequiredHeaders.Any(requiredHeader => !IsHeaderValid(originHeaders, requiredHeader)))
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Missing header(s)");
            return;
        }

        await _next.Invoke(context);
    }

    public static bool IsHeaderValid(IReadOnlyDictionary<string, string> headers, string key)
    {
        if (headers.Count == 0) return false;

        var hasValue = headers.TryGetValue(key, out var value);

        if (!hasValue)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(value))
        {
            return false;
        }

        return true;
    }
}
