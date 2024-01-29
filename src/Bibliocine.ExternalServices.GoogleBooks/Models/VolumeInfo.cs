using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.GoogleBooks.Models;

public class VolumeInfo
{
    [JsonPropertyName("title")] public string Title { get; set; }

    [JsonPropertyName("authors")] public List<string> Authors { get; set; }

    [JsonPropertyName("publisher")] public string Publisher { get; set; }

    [JsonPropertyName("publishedDate")] public string PublishedDate { get; set; }

    [JsonPropertyName("description")] public string Description { get; set; }

    [JsonPropertyName("pageCount")] public int PageCount { get; set; }

    [JsonPropertyName("printType")] public string PrintType { get; set; }

    [JsonPropertyName("categories")] public List<string> Categories { get; set; }

    [JsonPropertyName("maturityRating")] public string MaturityRating { get; set; }

    [JsonPropertyName("allowAnonLogging")] public bool AllowAnonLogging { get; set; }

    [JsonPropertyName("contentVersion")] public string ContentVersion { get; set; }

    [JsonPropertyName("imageLinks")] public ImageLinks ImageLinks { get; set; }

    [JsonPropertyName("language")] public string Language { get; set; }

    [JsonPropertyName("previewLink")] public string PreviewLink { get; set; }

    [JsonPropertyName("infoLink")] public string InfoLink { get; set; }

    [JsonPropertyName("canonicalVolumeLink")]
    public string CanonicalVolumeLink { get; set; }

    [JsonPropertyName("averageRating")] public double? AverageRating { get; set; }

    [JsonPropertyName("ratingsCount")] public int? RatingsCount { get; set; }
}