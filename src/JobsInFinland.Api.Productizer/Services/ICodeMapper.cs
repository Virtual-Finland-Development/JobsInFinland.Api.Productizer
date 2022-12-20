namespace JobsInFinland.Api.Productizer.Services;

public interface ICodeMapper
{
    public IReadOnlyList<string> GetNamesFromCodes(IEnumerable<string> codes);
}

public interface IOccupationCodeMapper : ICodeMapper
{
}

public interface IMunicipalityCodeMapper : ICodeMapper
{
}

