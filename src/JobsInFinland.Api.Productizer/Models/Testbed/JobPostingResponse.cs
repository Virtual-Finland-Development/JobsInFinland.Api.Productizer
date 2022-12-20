// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace JobsInFinland.Api.Productizer.Models.Testbed;

public record JobPostingResponse
{
    public IList<JobPosting> Results { get; init; } = null!;
    public int TotalCount { get; init; }
}
