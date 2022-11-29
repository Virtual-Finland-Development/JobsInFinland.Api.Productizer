namespace JobsInFinland.Api.Productizer.Services;

public interface IAuthorizationService
{
    Task Authorize(HttpRequest request);
}
