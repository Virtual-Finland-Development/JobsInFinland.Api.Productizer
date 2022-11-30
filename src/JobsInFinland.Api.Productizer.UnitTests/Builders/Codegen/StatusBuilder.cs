using JobsInFinland.Api.Infrastructure.CodeGen.Model;

namespace JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

internal class StatusBuilder
{
    private HiddenBecause _hiddenBecause = new();
    private string _publicationStatus = "";
    private ReportedBecause _reportedBecause = new();
    private string _reviewStatus = "";
    private Transformations _transformations = new();

    public StatusBuilder WithHiddenBecause(HiddenBecause value)
    {
        _hiddenBecause = value;
        return this;
    }

    public StatusBuilder WithPublicationStatus(string value)
    {
        _publicationStatus = value;
        return this;
    }

    public StatusBuilder WithReportedBecause(ReportedBecause value)
    {
        _reportedBecause = value;
        return this;
    }

    public StatusBuilder WithReviewStatus(string value)
    {
        _reviewStatus = value;
        return this;
    }

    public StatusBuilder WithTransformations(Transformations value)
    {
        _transformations = value;
        return this;
    }

    public Status Build()
    {
        return new Status(_reviewStatus, _hiddenBecause, _reportedBecause, _transformations, _publicationStatus);
    }
}
