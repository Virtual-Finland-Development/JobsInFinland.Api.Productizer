using FluentAssertions;
using JobsInFinland.Api.Productizer.Services;
using JobsInFinland.Api.Productizer.Services.Codeset;

namespace JobsInFinland.Api.Productizer.UnitTests.Services;

[TestFixture]
// ReSharper disable once InconsistentNaming
public class MunicipalityCodeMapper_UnitTests
{
    [Test]
    public void TryingToMapCode_WithValidCode_ShouldReturnName()
    {
        // Arrange
        IMunicipalityCodesetService codesetService = new MunicipalityCodesetService();
        var sut = new MunicipalityCodeMapper(codesetService);

        // Act
        var actual = sut.GetNamesFromCodes(new[] { "405" });

        // Assert
        actual.First().Should().BeEquivalentTo("Lappeenranta");
    }

    [Test]
    public void TryingToMapCode_WithInvalidCode_ShouldReturnEmptyList()
    {
        // Arrange
        IMunicipalityCodesetService service = new MunicipalityCodesetService();
        var sut = new MunicipalityCodeMapper(service);

        // Act
        var actual = sut.GetNamesFromCodes(new[] { "xd" });

        // Assert
        actual.Should().BeEmpty();
    }
}

