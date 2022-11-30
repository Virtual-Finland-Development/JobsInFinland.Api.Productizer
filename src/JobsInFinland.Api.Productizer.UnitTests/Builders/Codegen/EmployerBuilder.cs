using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class EmployerBuilder
{
    private string _aliasForId = "";
    private string _careersUrl = "";
    private string _externalUrl = "";
    private string _id = "";
    private string _imageUrl = "";
    private Location _location = new LocationBuilder().Build();
    private string _name = "";
    private string _source = "";

    public EmployerBuilder WithId(string value)
    {
        _id = value;
        return this;
    }

    public EmployerBuilder WithName(string value)
    {
        _name = value;
        return this;
    }

    public EmployerBuilder WithImageUrl(string value)
    {
        _imageUrl = value;
        return this;
    }

    public EmployerBuilder WithExternalUrl(string value)
    {
        _externalUrl = value;
        return this;
    }

    public EmployerBuilder WithCareersUrl(string value)
    {
        _careersUrl = value;
        return this;
    }

    public EmployerBuilder WithLocation(Location value)
    {
        _location = value;
        return this;
    }

    public EmployerBuilder WithSource(string value)
    {
        _source = value;
        return this;
    }

    public EmployerBuilder WithAliasForId(string value)
    {
        _aliasForId = value;
        return this;
    }

    public Employer Build()
    {
        return new Employer(_id, _name, _imageUrl, _externalUrl, _careersUrl, _location, _source, _aliasForId);
    }
}
