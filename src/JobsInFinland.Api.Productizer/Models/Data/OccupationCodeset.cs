using System.Text.Json.Serialization;

namespace JobsInFinland.Api.Productizer.Models.Data;

// ReSharper disable once ClassNeverInstantiated.Global
public class OccupationCodeset
{
    [JsonPropertyName("uri")]
    public string? Uri { get; init; }
    
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("notation")]
    public string? Notation { get; set; }
    
    [JsonPropertyName("prefLabel")]
    public PreferredLabel PrefLabel { get; set; }
    
    [JsonPropertyName("altLabel")]
    public AlternateLabel? AltLabel { get; set; }
    
    [JsonPropertyName("broader")]
    public List<string>? Broader { get; set; }
    
    [JsonPropertyName("relatedDataSkill")]
    public List<string>? RelatedEssentialSkills { get; set; }
}

// ReSharper disable once ClassNeverInstantiated.Global
public class AlternateLabel
{
    [JsonPropertyName("fi")]
    public List<string?> Fi { get; set; }
    
    [JsonPropertyName("sv")]
    public List<string?> Sv { get; set; }
    
    [JsonPropertyName("en")]
    public List<string?> En { get; set; }
}

// ReSharper disable once ClassNeverInstantiated.Global
public class PreferredLabel
{
    [JsonPropertyName("fi")]
    public string? Fi { get; set; }
    
    [JsonPropertyName("sv")]
    public string? Sv { get; set; }
    
    [JsonPropertyName("en")]
    public string? En { get; set; }
}

public enum LanguageCode
{
    [JsonPropertyName("fi")] Fi,
    [JsonPropertyName("en")] En,
    [JsonPropertyName("sv")] Sv
}

