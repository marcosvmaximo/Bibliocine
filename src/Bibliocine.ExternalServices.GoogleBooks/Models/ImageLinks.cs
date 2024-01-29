using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.GoogleBooks.Models;

public class ImageLinks
{
    [JsonPropertyName("smallThumbnail")]
    public string SmallThumbnail { get; set; }

    [JsonPropertyName("thumbnail")]
    public string Thumbnail { get; set; }
}