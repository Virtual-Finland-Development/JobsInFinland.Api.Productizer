// ReSharper disable ClassNeverInstantiated.Global

using System.Text.Json.Serialization;

namespace JobsInFinland.Api.Productizer.Models.Data;

internal record MunicipalityCodeset
{
    [JsonPropertyName("Koodi")] public string Code { get; set; } = null!;

    [JsonPropertyName("Alkupaiva")] public string BeginDate { get; set; } = null!;

    [JsonPropertyName("Loppupaiva")] public string EndDate { get; set; } = null!;

    [JsonPropertyName("Muokkausaika")] public string EditedAt { get; set; } = null!;

    [JsonPropertyName("Selitteet")] public List<Name> Names { get; set; } = null!;

    [JsonPropertyName("Laajennukset")] public List<Expansion> Expansions { get; set; } = null!;
}

internal record Name
{
    [JsonPropertyName("Kielikoodi")] public string LanguageCode { get; set; } = null!;

    [JsonPropertyName("Teksti")] public string Text { get; set; } = null!;
}

internal record Expansion
{
    [JsonPropertyName("Tyyppi")] public string Type { get; set; } = null!;

    [JsonPropertyName("Kategoria")] public List<string> Category { get; set; } = null!;

    [JsonPropertyName("Arvo")] public string Arvo { get; set; } = null!;

    [JsonPropertyName("Alkupaiva")] public string BeginDate { get; set; } = null!;

    [JsonPropertyName("Loppupaiva")] public string EndDate { get; set; } = null!;

    [JsonPropertyName("Muokkausaika")] public string EditedAt { get; set; } = null!;
}
