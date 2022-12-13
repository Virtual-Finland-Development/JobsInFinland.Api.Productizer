using System.Text.Json.Serialization;
// ReSharper disable ClassNeverInstantiated.Global

namespace JobsInFinland.Api.Productizer.Models.Data;

internal record MunicipalityCodeset {
    [JsonPropertyName("Koodi")]
    public string Code { get; set; }

    [JsonPropertyName("Alkupaiva")]
    public string BeginDate { get; set; }
    
    [JsonPropertyName("Loppupaiva")]
    public string EndDate { get; set; }
    
    [JsonPropertyName("Muokkausaika")]
    public string EditedAt { get; set; }
    
    [JsonPropertyName("Selitteet")]
    public List<Name> Names { get; set; }
    
    [JsonPropertyName("Laajennukset")]
    public List<Expansion> Expansions { get; set; }
}

internal record Name
{
    [JsonPropertyName("Kielikoodi")]
    public string LanguageCode { get; set; }
    
    [JsonPropertyName("Teksti")]
    public string Text { get; set; }
}

internal record Expansion
{
    [JsonPropertyName("Tyyppi")]
    public string Type { get; set; }
    
    [JsonPropertyName("Kategoria")]
    public List<string> Category { get; set; }
    
    [JsonPropertyName("Arvo")]
    public string Arvo { get; set; }
    
    [JsonPropertyName("Alkupaiva")]
    public string BeginDate { get; set; }
    
    [JsonPropertyName("Loppupaiva")]
    public string EndDate { get; set; }
    
    [JsonPropertyName("Muokkausaika")]
    public string EditedAt { get; set; }
}
