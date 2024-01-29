using System.Text.Json.Serialization;
using Bibliocine.ExternalServices.IMDB.Models;

namespace Bibliocine.ExternalServices.IMDB.DTO;

public class TitleResults
{
    [JsonPropertyName("results")]
    public List<Result> Results { get; set; }

    [JsonPropertyName("nextCursor")]
    public string NextCursor { get; set; }

    [JsonPropertyName("hasExactMatches")]
    public bool HasExactMatches { get; set; }
}