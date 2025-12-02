using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class ZanpakutoDTO
    {
        [JsonPropertyName("shikai")]
        public string Shikai { get; init; } = string.Empty;
        [JsonPropertyName("bankai")]
        public string Bankai { get; init; } = string.Empty;
    }
}
