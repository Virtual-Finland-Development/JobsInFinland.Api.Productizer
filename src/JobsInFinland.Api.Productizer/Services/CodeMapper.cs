using JobsInFinland.Api.Productizer.Services.Codeset;

namespace JobsInFinland.Api.Productizer.Services;

public class CodeMapper : ICodeMapper
{
    private readonly IDictionary<string,string> _codes;

    public CodeMapper(ICodesetService service)
    {
        _codes = service.GetCodeset();
    }

    public IReadOnlyList<string> GetNamesFromCodes(IEnumerable<string> codes)
    {
        var names = new List<string>();

        foreach (var code in codes)
        {
            var codeNamePair = _codes.FirstOrDefault(o => o.Key == code);
            if (codeNamePair is { Key: { }, Value: { } }) names.Add(codeNamePair.Value);
        }

        return names;
    }
}
