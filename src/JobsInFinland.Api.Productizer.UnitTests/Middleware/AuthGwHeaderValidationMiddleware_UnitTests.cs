using System.Net;
using FluentAssertions;
using JobsInFinland.Api.Productizer.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;

namespace JobsInFinland.Api.Productizer.UnitTests.Middleware;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class AuthGwHeaderValidationMiddleware_UnitTests
{
    // TODO: This doesn't actually work like it's supposed to ":D"
    [Test]
    public async Task Invoke_WithMissingHeaders_ShouldThrowException401()
    {
        using var host = await new HostBuilder()
            .ConfigureWebHost(builder =>
            {
                builder
                    .UseTestServer()
                    .ConfigureTestServices(services => { services.AddSingleton<AuthGwHeaderOptions>(); })
                    .Configure(app =>
                    {
                        app.UseMiddleware<AuthGwHeaderValidationMiddleware>();
                        app.UseAuthGwHeaderValidation(options =>
                        {
                            var required = options.RequiredHeaders;
                            required.Add("authorization");
                        });
                    });
            })
            .StartAsync();

        var actual = await host.GetTestClient().GetAsync("/");

        actual.StatusCode.Should().Subject.Should().HaveSameNameAs(HttpStatusCode.Unauthorized);
    }

    [Test]
    public void TestingIfHeaderIsValid_WithValidHeader_ReturnsTrue()
    {
        IReadOnlyDictionary<string, string> headers = new Dictionary<string, string>
        {
            { "Authorization", "Bearer xyz" }
        };
        var actual = AuthGwHeaderValidationMiddleware.IsHeaderValid(headers, "Authorization");

        actual.Should().BeTrue();
    }

    [TestCase("")]
    [TestCase(null)]
    public void TestingIfHeaderIsValid_WithEmptyOrMissingHeaderValue_ReturnsFalse(string value)
    {
        IReadOnlyDictionary<string, string> headers = new Dictionary<string, string>
        {
            { "Authorization", value }
        };
        var actual = AuthGwHeaderValidationMiddleware.IsHeaderValid(headers, "Authorization");

        actual.Should().BeFalse("Invalid header value received from context");
    }

    [Test]
    public void TestingIfHeaderIsValid_WithEmptyHeadersList_ReturnsFalse()
    {
        IReadOnlyDictionary<string, string> headers = new Dictionary<string, string>();
        var actual = AuthGwHeaderValidationMiddleware.IsHeaderValid(headers, It.IsAny<string>());

        actual.Should().BeFalse();
    }
}
