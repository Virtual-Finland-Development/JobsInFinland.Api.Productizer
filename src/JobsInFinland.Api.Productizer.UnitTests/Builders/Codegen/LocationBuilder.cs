using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class LocationBuilder
{
    private string _area = "";
    private string _city = "";
    private string _country = "";

    public LocationBuilder WithCity(string value)
    {
        _city = value;
        return this;
    }

    public LocationBuilder WithArea(string value)
    {
        _area = value;
        return this;
    }

    public LocationBuilder WithCountry(string value)
    {
        _country = value;
        return this;
    }

    public Location Build()
    {
        return new Location(_city, _area, _country);
    }
}
