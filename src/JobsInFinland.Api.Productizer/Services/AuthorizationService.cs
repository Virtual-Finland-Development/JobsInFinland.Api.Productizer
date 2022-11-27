using System.Net;

namespace JobsInFinland.Api.Productizer.Services;

internal class AuthorizationService : IAuthorizationService
{
    private readonly HttpClient _client;

    public AuthorizationService(HttpClient client)
    {
        _client = client;
    }

    public async Task Authorize(HttpRequest request)
    {
        var headers = request.Headers.ToDictionary(
            x => x.Key.ToLowerInvariant(),
            x => x.Value.ToString());

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _client.BaseAddress + "authorize");
        requestMessage.Headers.Add("authorization", headers["authorization"]);
        requestMessage.Headers.Add("x-authorization-provider", headers["x-authorization-provider"]);
        requestMessage.Headers.Add("x-authorization-context", "jif-productizer");

        var result = await _client.SendAsync(requestMessage);
        if (!result.IsSuccessStatusCode)
            throw new HttpRequestException("Access Denied", null, HttpStatusCode.Unauthorized);
    }
}
