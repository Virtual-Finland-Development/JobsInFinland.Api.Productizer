// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

using System.Text.Json.Serialization;

namespace JobsInFinland.Api.Productizer.Models.Data;

public class OccupationCodeset
{
    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("notation")]
    public string? Notation { get; set; }

    [JsonPropertyName("prefLabel")] public PreferredLabel PrefLabel { get; set; } = null!;
    
    [JsonPropertyName("altLabel")]
    public AlternateLabel? AltLabel { get; set; }
    
    [JsonPropertyName("broader")]
    public List<string>? Broader { get; set; }
    
    [JsonPropertyName("relatedDataSkill")]
    public List<string>? RelatedEssentialSkills { get; set; }
}

public class AlternateLabel
{
    [JsonPropertyName("fi")] public List<string?> Fi { get; set; } = null!;

    [JsonPropertyName("sv")] public List<string?> Sv { get; set; } = null!;

    [JsonPropertyName("en")] public List<string?> En { get; set; } = null!;
}

public class PreferredLabel
{
    [JsonPropertyName("fi")] public string? Fi { get; set; } = null!;
    [JsonPropertyName("sv")] public string? Sv { get; set; } = null!;
    [JsonPropertyName("en")] public string? En { get; set; } = null!;
}
