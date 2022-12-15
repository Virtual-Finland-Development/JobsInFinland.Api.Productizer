using FluentAssertions;
using JobsInFinland.Api.Productizer.Services;

namespace JobsInFinland.Api.Productizer.UnitTests.Services;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class OccupationCodeMapper_UnitTests
{
    [Test]
    public void TryingToMapCode_WithValidCode_ShouldReturnMatchingName()
    {
        IOccupationCodesetService service = new OccupationCodesetService();
        var sut = new OccupationCodeMapper(service);

        var actual = sut.GetNamesFromCodes(new[] { "01" });

        actual.First().Should().BeEquivalentTo("Commissioned armed forces officers");
    }

    [Test]
    public void TryingToMapCode_WithInvalidCode_ShouldReturnEmptyList()
    {
        IOccupationCodesetService service = new OccupationCodesetService();
        var sut = new OccupationCodeMapper(service);

        var actual = sut.GetNamesFromCodes(new[] { "xd" });

        actual.Should().BeEmpty();
    }
}
