namespace JobsInFinland.Api.Productizer.Services;

public interface ILocationCodeMapper
{
    public IReadOnlyList<string> GetNamesFromCodes(IEnumerable<string> municipalities);
}

