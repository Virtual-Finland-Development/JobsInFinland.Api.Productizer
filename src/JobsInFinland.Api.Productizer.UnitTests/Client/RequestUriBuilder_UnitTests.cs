using FluentAssertions;
using JobsInFinland.Api.Productizer.Client;
using JobsInFinland.Api.Productizer.Models.Testbed;
using Moq;

namespace JobsInFinland.Api.Productizer.UnitTests.Client;

// ReSharper disable once InconsistentNaming
[TestFixture]
public class RequestUriBuilder_UnitTests
{
    [Test]
    public void CreatingSearchQuery_WithoutLimit_ShouldReturnStringWithoutLimitParameter()
    {
        var sut = new RequestUriBuilder();

        var actual = sut.WithPaging(new PagingOptions { Limit = null, Offset = It.IsAny<int>() }).Build();

        actual.Should().BeOfType<string>();
        actual.Should().NotContain("&limit");
    }

    [Test]
    public void CreatingSearchQuery_WithPaginationWithoutOptions_ShouldReturnMatchingString()
    {
        var sut = new RequestUriBuilder();

        var actual = sut
            .WithEndpoint("jobs")
            .WithPaging(new PagingOptions { Limit = 1, Offset = 2 })
            .Build();

        actual.Should().BeOfType<string>();
        actual.Should().BeEquivalentTo("jobs?meta=true&offset=2&limit=1");
    }

    [Test]
    public void CreatingSearchQuery_WithOptionsAndKeywords_ShouldReturnString()
    {
        var sut = new RequestUriBuilder();

        var actual = sut
            .WithEndpoint("jobs")
            .WithPaging(new PagingOptions { Limit = 1, Offset = 0 })
            .WithQueryOption(new KeyValuePair<string, string>("key", "value"))
            .Build();

        actual.Should().BeOfType<string>();
        actual.Should().BeEquivalentTo("jobs?meta=true&offset=0&limit=1&key=value");
    }

    [Test]
    public void CreatingSearchQuery_WithAllOptions_ShouldReturnString()
    {
        var sut = new RequestUriBuilder();

        var actual = sut
            .WithEndpoint("jobs")
            .WithPaging(new PagingOptions { Limit = 1, Offset = 0 })
            .WithCity("Lappeenranta")
            .WithCategory("consulting")
            .WithSorting("title")
            .OrderBy(RequestUriBuilder.Direction.Descending)
            .WithQueryOption(new KeyValuePair<string, string>("key", "value"))
            .Build();

        actual.Should().BeOfType<string>();
        actual.Should()
            .BeEquivalentTo(
                "jobs?meta=true&offset=0&limit=1&city=Lappeenranta&category=consulting&sort=title&order=-1&key=value");
    }
}

