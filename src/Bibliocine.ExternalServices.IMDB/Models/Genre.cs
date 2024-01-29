using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.Models;

public class Genre
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}