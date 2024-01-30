using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.Models;

public class TMDBGenreResult
{
    [JsonPropertyName("genres")]
    public List<Genre> Genres { get; set; }
}