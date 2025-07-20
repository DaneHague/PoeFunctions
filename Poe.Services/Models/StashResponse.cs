using System.Text.Json.Serialization;

namespace Poe.Services.Models;

public class StashResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; }
    [JsonPropertyName("index")]
    public int Index { get; set; }  
}