namespace JobsInFinland.Api.Productizer.Services;

public interface ICodeMapperFactory
{
    public ICodeMapper CreateForMunicipalityCode();
    public ICodeMapper CreateForOccupationCode();
}
