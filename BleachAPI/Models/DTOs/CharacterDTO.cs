using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class CharacterDTO
    {
        [JsonPropertyName("id")]
        public string Id { get; init; } = string.Empty;
        [JsonPropertyName("name")]
        public NameDTO Name { get; init; } = new NameDTO();
        [JsonPropertyName("description")]
        public string Description { get; init; } = string.Empty;
        [JsonPropertyName("stats")]
        public StatsDTO Stats { get; init; } = new StatsDTO();
        [JsonPropertyName("slug")]
        public string Slug { get; init; } = string.Empty;
    }
}
