using System.Text.Json.Serialization;

namespace Bibliocine.ExternalServices.IMDB.Models;

public class Result
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("titleNameText")]
    public string TitleNameText { get; set; }

    [JsonPropertyName("titleReleaseText")]
    public string TitleReleaseText { get; set; }

    [JsonPropertyName("titleTypeText")]
    public string TitleTypeText { get; set; }

    [JsonPropertyName("titlePosterImageModel")]
    public ImageModel TitlePosterImageModel { get; set; }

    [JsonPropertyName("topCredits")]
    public List<string> TopCredits { get; set; }

    [JsonPropertyName("imageType")]
    public string ImageType { get; set; }

    [JsonPropertyName("displayNameText")]
    public string DisplayNameText { get; set; }

    [JsonPropertyName("knownForJobCategory")]
    public string KnownForJobCategory { get; set; }

    [JsonPropertyName("knownForTitleText")]
    public string KnownForTitleText { get; set; }

    [JsonPropertyName("knownForTitleYear")]
    public string KnownForTitleYear { get; set; }

    [JsonPropertyName("avatarImageModel")]
    public ImageModel AvatarImageModel { get; set; }
}