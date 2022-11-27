using Microsoft.Extensions.Options;

namespace JobsInFinland.Api.Productizer.Middleware;

public static class AuthGwBuilderExtensions
{
    public static IApplicationBuilder UseAuthGwAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthGwAuthorizationMiddleware>();
    }


    private static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        AuthGwHeaderOptions options)
    {
        return builder.UseMiddleware<AuthGwHeaderValidationMiddleware>(options);
    }

    public static IApplicationBuilder UseAuthGwHeaderValidation(this IApplicationBuilder builder,
        Action<AuthGwHeaderOptions>? setupAction)
    {
        AuthGwHeaderOptions options;
        using (var scope = builder.ApplicationServices.CreateScope())
        {
            options = scope.ServiceProvider.GetRequiredService<IOptionsSnapshot<AuthGwHeaderOptions>>().Value;
            setupAction?.Invoke(options);
        }

        if (!options.RequiredHeaders.Any()) options.RequiredHeaders.Add("x-authorization-header");

        return builder.UseAuthGwHeaderValidation(options);
    }
}
