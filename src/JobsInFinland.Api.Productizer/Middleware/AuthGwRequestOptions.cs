namespace JobsInFinland.Api.Productizer.Middleware;

public class AuthGwRequestOptions
{
    public List<string> RequiredHeaders { get; } = new();
    public List<string> AllowedRequestPaths { get; set; } = new();
}
