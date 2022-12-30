using Microsoft.Extensions.Options;

namespace JobsInFinland.Api.Productizer.Middleware;

public static class AuthGwBuilderExtensions
{
    public static IApplicationBuilder UseAuthGwAuthorization(this IApplicationBuilder builder, Action<AuthGwOptions>? setupAction)
    {
        AuthGwOptions options;
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AuthGwOptions>>().Value;
            setupAction?.Invoke(options);
        }
        return builder.UseMiddleware<AuthGwAuthorizationMiddleware>(options);
    }

    private static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        AuthGwOptions options)
    {
        return builder.UseMiddleware<AuthGwHeaderValidationMiddleware>(options);
    }

    public static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        Action<AuthGwOptions>? setupAction)
    {
        AuthGwOptions options;
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AuthGwOptions>>().Value;
            setupAction?.Invoke(options);
        }

        if (!options.RequiredHeaders.Any()) options.RequiredHeaders.Add("x-authorization-header");

        return builder.UseAuthGwHeaderValidation(options);
    }
}
