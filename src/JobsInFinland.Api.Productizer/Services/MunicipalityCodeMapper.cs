namespace JobsInFinland.Api.Productizer.Services;

public class MunicipalityCodeMapper : ILocationCodeMapper
{
    private readonly IDictionary<string, string> _codes;

    public MunicipalityCodeMapper(ICodesetService codesetService)
    {
        _codes = codesetService.GetCodeset();
    }

    public IReadOnlyList<string> GetNamesFromCodes(IEnumerable<string> municipalities)
    {
        var codes = new List<string>();

        foreach (var municipality in municipalities)
        {
            var codeNamePair = _codes.FirstOrDefault(o => o.Key == municipality);
            if (codeNamePair is { Key: { }, Value: { } }) codes.Add(codeNamePair.Value);
        }

        return codes;
    }
}




