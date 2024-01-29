using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.DTO;

public class IMDBResult
{
    [JsonPropertyName("titleResults")]
    public TitleResults TitleResponse { get; set; }

    [JsonPropertyName("nameResults")]
    public NameResults NameResponse { get; set; }
}
