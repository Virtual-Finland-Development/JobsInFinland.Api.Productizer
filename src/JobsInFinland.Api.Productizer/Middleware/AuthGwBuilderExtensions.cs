using Microsoft.Extensions.Options;

namespace JobsInFinland.Api.Productizer.Middleware;

public static class AuthGwBuilderExtensions
{
    public static IApplicationBuilder UseAuthGwAuthorization(this IApplicationBuilder builder, Action<AuthGwRequestOptions>? setupAction)
    {
        AuthGwRequestOptions options;
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AuthGwRequestOptions>>().Value;
            setupAction?.Invoke(options);
        }
        return builder.UseMiddleware<AuthGwAuthorizationMiddleware>(options);
    }

    private static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        AuthGwRequestOptions options)
    {
        return builder.UseMiddleware<AuthGwHeaderValidationMiddleware>(options);
    }

    public static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        Action<AuthGwRequestOptions>? setupAction)
    {
        AuthGwRequestOptions options;
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AuthGwRequestOptions>>().Value;
            setupAction?.Invoke(options);
        }

        if (!options.RequiredHeaders.Any()) options.RequiredHeaders.Add("x-authorization-header");

        return builder.UseAuthGwHeaderValidation(options);
    }
}
