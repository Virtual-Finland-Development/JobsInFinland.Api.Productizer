namespace JobsInFinland.Api.Productizer.Services;

public class MunicipalityCodeMapper : ILocationCodeMapper
{
    private readonly IDictionary<string, string> _codeset;

    public MunicipalityCodeMapper(ICodesetService codesetService)
    {
        _codeset = codesetService.GetCodeset();
    }

    public IReadOnlyList<string> GetNamesFromCodes(IEnumerable<string> codes)
    {
        var names = new List<string>();

        foreach (var code in codes)
        {
            var codeNamePair = _codeset.FirstOrDefault(o => o.Key == code);
            if (codeNamePair is { Key: { }, Value: { } }) names.Add(codeNamePair.Value);
        }

        return names;
    }
}




