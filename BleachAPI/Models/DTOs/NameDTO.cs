using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class NameDTO
    {
        [JsonPropertyName("english")]
        public string English { get; init; } = "";

        [JsonPropertyName("kanji")]
        public string Kanji { get; init; } = "";

        [JsonPropertyName("romaji")]
        public string Romaji { get; init; } = "";
    }
}
