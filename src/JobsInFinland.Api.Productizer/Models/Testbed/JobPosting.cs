namespace JobsInFinland.Api.Productizer.Models.Testbed;

internal record JobPosting
{
    public string? Employer { get; set; }
    public Location Location { get; set; } = null!;
    public BasicInfo BasicInfo { get; set; } = null!;
    public DateTime PublishedAt { get; set; }
    public DateTime ApplicationEndDate { get; set; }
    public string? ApplicationUrl { get; set; }
}

internal record BasicInfo
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string WorkTimeType { get; set; } = null!;
}

internal record Location
{
    public string City { get; set; } = null!;
    public string Postcode { get; set; } = null!;
}
