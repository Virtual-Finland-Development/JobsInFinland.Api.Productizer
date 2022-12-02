using System.Net;

namespace JobsInFinland.Api.Productizer.Services;

public class AuthorizationService : IAuthorizationService
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

        headers.TryGetValue("authorization", out var authorization);

        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, _client.BaseAddress + "authorize");

        requestMessage.Headers.Add("authorization",
            authorization ?? throw new InvalidOperationException("Missing header: Authorization"));

        requestMessage.Headers.Add("x-authorization-context", "jif-productizer");

        var result = await _client.SendAsync(requestMessage);
        if (!result.IsSuccessStatusCode)
            throw new HttpRequestException("Access Denied", null, HttpStatusCode.Unauthorized);
    }
}
