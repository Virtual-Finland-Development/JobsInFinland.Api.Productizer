namespace JobsInFinland.Api.Productizer.Services.Codeset;

public interface ICodesetService
{
    IDictionary<string, string> GetCodeset();
}

public interface IOccupationCodesetService : ICodesetService
{
}

public interface IMunicipalityCodesetService : ICodesetService
{
}

