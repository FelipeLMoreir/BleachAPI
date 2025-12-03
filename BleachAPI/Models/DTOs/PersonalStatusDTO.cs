using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class PersonalStatusDTO
    {
        [JsonPropertyName("relatives")]
        public List<string> Relatives { get; init; } = new();

        [JsonPropertyName("education")]
        public string Education { get; init; } = "";
    }
}
