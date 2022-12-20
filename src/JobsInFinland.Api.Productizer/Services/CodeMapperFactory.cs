using JobsInFinland.Api.Productizer.Services.Codeset;

namespace JobsInFinland.Api.Productizer.Services;

public class CodeMapperFactory : ICodeMapperFactory
{
    private readonly IMunicipalityCodesetService _municipalityCodesetService;
    private readonly IOccupationCodesetService _occupationCodesetService;

    public CodeMapperFactory(IMunicipalityCodesetService municipalityCodesetService,
        IOccupationCodesetService occupationCodesetService)
    {
        _municipalityCodesetService = municipalityCodesetService;
        _occupationCodesetService = occupationCodesetService;
    }

    public ICodeMapper CreateForMunicipalityCode()
    {
        return new CodeMapper(_municipalityCodesetService);
    }

    public ICodeMapper CreateForOccupationCode()
    {
        return new CodeMapper(_occupationCodesetService);
    }
}
