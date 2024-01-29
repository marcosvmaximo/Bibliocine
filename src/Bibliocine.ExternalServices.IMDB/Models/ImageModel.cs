using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.Models;

public class ImageModel
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("maxHeight")]
    public int MaxHeight { get; set; }

    [JsonPropertyName("maxWidth")]
    public int MaxWidth { get; set; }

    [JsonPropertyName("caption")]
    public string Caption { get; set; }
}