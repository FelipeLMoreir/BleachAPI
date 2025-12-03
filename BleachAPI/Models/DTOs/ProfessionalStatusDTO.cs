using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class ProfessionalStatusDTO
    {
        [JsonPropertyName("affiliation")]
        public List<string> Affiliation { get; init; } = new();

        [JsonPropertyName("previous affiliation")]
        public List<string> PreviousAffiliation { get; init; } = new();

        [JsonPropertyName("occupation")]
        public string Occupation { get; init; } = "";

        [JsonPropertyName("base of operations")]
        public List<string> BaseOfOperations { get; init; } = new();
    }
}
