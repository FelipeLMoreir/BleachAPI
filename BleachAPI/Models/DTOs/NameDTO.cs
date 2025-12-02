using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class NameDTO
    {
        [JsonPropertyName("english")]
        public string NameEnglish { get; init; } = string.Empty;
        [JsonPropertyName("kanji")]
        public string NameKanji { get; init; } = string.Empty;
        [JsonPropertyName("romaji")]
        public string NameRomaji { get; init; } = string.Empty;
    }
}
