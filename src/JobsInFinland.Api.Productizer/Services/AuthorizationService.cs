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

        var authorizationRequest = new HttpRequestMessage
        {
            RequestUri = new Uri($"{_client.BaseAddress}authorize"),
            Method = HttpMethod.Post,
            Headers =
            {
                { "authorization", headers["authorization"] },
                { "x-authorization-provider", headers["x-authorization-provider"] },
                { "x-authorization-context", "TMT-productizer" }
            }
        };

        var result = await _client.SendAsync(authorizationRequest);
        if (!result.IsSuccessStatusCode)
            throw new HttpRequestException("Access Denied", null, HttpStatusCode.Unauthorized);
    }
}
