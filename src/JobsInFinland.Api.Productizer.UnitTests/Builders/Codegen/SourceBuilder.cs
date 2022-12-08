using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class SourceBuilder
{
    private string _apiId = "";
    private string _contactEmail = "";
    private string _documentId = "";
    private string _firstSeen = "";
    private string _lastSeen = "";

    public SourceBuilder WithApiId(string value)
    {
        _apiId = value;
        return this;
    }

    public SourceBuilder WithDocumentId(string value)
    {
        _documentId = value;
        return this;
    }

    public SourceBuilder WithFirstSeen(string value)
    {
        _firstSeen = value;
        return this;
    }

    public SourceBuilder WithLastSeen(string value)
    {
        _lastSeen = value;
        return this;
    }

    public SourceBuilder WithContactEmail(string value)
    {
        _contactEmail = value;
        return this;
    }

    public Source Build()
    {
        return new Source(_apiId, _documentId, _firstSeen, _lastSeen, _contactEmail);
    }
}
