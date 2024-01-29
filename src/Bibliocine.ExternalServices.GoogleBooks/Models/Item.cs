using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.GoogleBooks.Models;

public class Item
{
    [JsonPropertyName("kind")]
    public string Kind { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("etag")]
    public string Etag { get; set; }

    [JsonPropertyName("selfLink")]
    public string SelfLink { get; set; }

    [JsonPropertyName("volumeInfo")]
    public VolumeInfo VolumeInfo { get; set; }
}