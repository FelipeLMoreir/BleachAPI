using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class ProfessionalStatusDTO
    {
        [JsonPropertyName("affiliation")]
        public List<string> Affiliation { get; init; } = new List<string>();
        [JsonPropertyName("previous affiliation")]
        public List<string> PreviousAffiliation { get; init; } = new List<string>();
        [JsonPropertyName("occupation")]
        public string Occupation { get; init; } = string.Empty;
        [JsonPropertyName("base of operations")]
        public List<string> BaseOps { get; init; } = new List<string>();
    }
}
