using FluentAssertions;
using JobsInFinland.Api.Infrastructure.CodeGen.Model;
using JobsInFinland.Api.Productizer.Services;
using JobsInFinland.Api.Productizer.UnitTests.Builders.Codegen;

namespace JobsInFinland.Api.Productizer.UnitTests.Services;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class JobPostingMapper_UnitTests
{
    [Test]
    public void TryingToMapResult_WithValidData_DataShouldMatch()
    {
        var jobs = new List<Job>
        {
            new JobBuilder()
                .WithLocation(new Location("Helsinki"))
                .WithExternalUrl("http://localhost")
                .WithEmployer(new EmployerBuilder().WithName("Virtual Finland").Build())
                .Build()
        };

        var sut = new JobPostingMapper();

        var actual = sut.From(jobs);
        actual.Should().NotBeEmpty();
        actual.First().Location.Municipality.Should().BeSameAs("Helsinki");
        actual.First().ApplicationUrl.Should().BeSameAs("http://localhost");
        actual.First().Employer.Should().BeSameAs("Virtual Finland");
    }

    [Test]
    public void TryingToMapResult_WithNullFields_ShouldNotSucceed()
    {
        var jobs = new List<Job>
        {
            new JobBuilder()
                .WithDescription(null!)
                .WithTitle(null!)
                .WithExternalUrl(null!)
                .Build()
        };

        var sut = new JobPostingMapper();

        var actual = sut.From(jobs);
        actual.Should().NotBeEmpty();
        actual.First().BasicInfo.Title.Should().BeNull();
        actual.First().BasicInfo.Description.Should().BeNull();
        actual.First().ApplicationUrl.Should().BeNull();
    }
}
