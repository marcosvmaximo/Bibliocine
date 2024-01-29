using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.Models;

public class GenreResult
{
    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; }
}