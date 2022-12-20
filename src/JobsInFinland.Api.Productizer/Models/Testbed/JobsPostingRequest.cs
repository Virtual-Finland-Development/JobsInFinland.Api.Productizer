// ReSharper disable ClassNeverInstantiated.Global

namespace JobsInFinland.Api.Productizer.Models.Testbed;

public class JobsPostingRequest
{
    public string Query { get; set; } = null!;
    public LocationQuery Location { get; set; } = null!;
    public Requirements Requirements { get; set; } = null!;
    public PagingOptions Paging { get; set; } = null!;
}

public class Requirements
{
    public List<string> Occupations { get; set; } = null!;
    public List<string> Skills { get; set; } = null!;
}

public class LocationQuery
{
    public IEnumerable<string> Countries { get; set; } = null!;
    public IEnumerable<string> Regions { get; set; } = null!;
    public IEnumerable<string> Municipalities { get; set; } = null!;
}

public class PagingOptions
{
    public int? Limit { get; init; } = 100;
    public int Offset { get; init; } = 0;
}
