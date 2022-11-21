namespace JobsInFinland.Api.Productizer.Models.Testbed;

public record JobPostingResponse
{
    public IList<JobPosting> Results { get; set; }
    public int TotalCount { get; set; }
}