using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class PersonalStatusDTO
    {
        [JsonPropertyName("relatives")]
        public List<string> Relatives { get; init; } = new List<string>();
        [JsonPropertyName("education")]
        public string Education { get; init; } = string.Empty;
    }
}
