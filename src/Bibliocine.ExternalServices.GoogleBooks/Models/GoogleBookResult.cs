using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Bibliocine.ExternalServices.GoogleBooks.Models;

public class GoogleBookResult
{
    [JsonPropertyName("totalItems")]
    public int TotalItems { get; set; }
    
    [JsonPropertyName("items")]
    public List<BookResult> Books { get; set; }
}