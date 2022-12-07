using System.Net;
using FluentAssertions;
using JobsInFinland.Api.Productizer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Moq;
using Moq.Protected;

namespace JobsInFinland.Api.Productizer.UnitTests.Services;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class AuthorizationService_UnitTests
{
    [Test]
    public async Task Authorize_WithValidAuthorizationHeader_ShouldNotThrowError()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ReturnsAsync(new HttpResponseMessage());
        var httpClient = new HttpClient(handler.Object) { BaseAddress = new Uri("http://localhost/") };

        var headers = new HeaderDictionary(new Dictionary<string, StringValues>
        {
            { "Authorization", "Bearer abc" },
            { "X-Authorization-Context", "jif-productizer" }
        }) as IHeaderDictionary;

        var httpRequest = new Mock<HttpRequest>();
        httpRequest.Setup(e => e.Headers).Returns(headers);

        var sut = new AuthorizationService(httpClient);

        // Act
        Func<Task> act = () => sut.Authorize(httpRequest.Object);

        // Act
        await act.Should().NotThrowAsync();
    }

    [Test]
    public void Authorize_WithMissingHeaders_ShouldThrowError()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ReturnsAsync(new HttpResponseMessage());

        var httpClient = new HttpClient(handler.Object) { BaseAddress = new Uri("http://localhost/") };

        var httpRequest = new Mock<HttpRequest>();
        httpRequest.Setup(e => e.Headers).Returns(new HeaderDictionary());

        var sut = new AuthorizationService(httpClient);

        // Act
        Task Act()
        {
            return sut.Authorize(httpRequest.Object);
        }

        // Assert
        var ex = Assert.ThrowsAsync<InvalidOperationException>(Act);
        ex.Should().BeOfType<InvalidOperationException>();
        ex?.Message.Should().BeEquivalentTo("Missing header: Authorization");
    }

    [Test]
    public void Authorize_WithAccessDenied_ShouldThrowError()
    {
        // Arrange
        var handler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        handler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            ).ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Unauthorized
            });

        var httpClient = new HttpClient(handler.Object) { BaseAddress = new Uri("http://localhost/") };

        var headers = new HeaderDictionary(new Dictionary<string, StringValues>
        {
            { "Authorization", "Bearer ABC" },
            { "X-Authorization-Context", "jif-productizer" }
        }) as IHeaderDictionary;

        var httpRequest = new Mock<HttpRequest>();
        httpRequest.Setup(e => e.Headers).Returns(headers);

        var sut = new AuthorizationService(httpClient);

        // Act
        Task Act()
        {
            return sut.Authorize(httpRequest.Object);
        }

        // Assert
        var ex = Assert.ThrowsAsync<HttpRequestException>(Act);
        ex.Should().BeOfType<HttpRequestException>();
        ex.Should().NotBeNull();
        ex?.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        ex.Message.Should().BeEquivalentTo("Access denied");
    }
}








