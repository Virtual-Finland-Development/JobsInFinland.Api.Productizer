using System.Net;
using FluentAssertions;
using JobsInFinland.Api.Productizer.Middleware;
using JobsInFinland.Api.Productizer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JobsInFinland.Api.Productizer.UnitTests.Middleware;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class AuthGwAuthorizationMiddleware_UnitTests
{
    [Test]
    public async Task Invoke_WithMissingHeaders_ShouldCatchException500()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(builder =>
            {
                builder
                    .UseTestServer()
                    .ConfigureTestServices(services => { services.AddSingleton<AuthGwRequestOptions>(); })
                    .ConfigureServices(services =>
                    {
                        services.AddSingleton<IAuthorizationService, AuthorizationService>();
                        services.AddHttpClient<IAuthorizationService, AuthorizationService>();
                    })
                    .Configure(app =>
                    {
                        app.UseMiddleware<AuthGwAuthorizationMiddleware>();
                        app.UseAuthGwAuthorization(options =>
                        {
                            var allowed = options.AllowedRequestPaths;
                            allowed.Add("/wake-up");
                        });
                    });
            })
            .StartAsync();
        var actual = await host.GetTestClient().GetAsync("/");

        actual.StatusCode.Should().Subject.Should().HaveSameNameAs(HttpStatusCode.InternalServerError);
    }
}
