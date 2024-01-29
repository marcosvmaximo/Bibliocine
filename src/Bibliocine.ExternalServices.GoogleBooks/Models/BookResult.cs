using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.GoogleBooks.Models;

public class BookResult
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("selfLink")]
    public string SelfLink { get; set; }

    [JsonPropertyName("volumeInfo")]
    public VolumeInfo VolumeInfo { get; set; }
}