using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class StatsDTO
    {
        [JsonPropertyName("race")]
        public string Race { get; init; } = string.Empty;
        [JsonPropertyName("birthday")]
        public string Birthday { get; init; } = string.Empty;
        [JsonPropertyName("age")]
        public string Age { get; init; } = string.Empty;
        [JsonPropertyName("gender")]
        public string Gender { get; init; } = string.Empty;
        [JsonPropertyName("Professional Status")]
        public ProfessionalStatusDTO ProfessionalStatus { get; init; } = new ProfessionalStatusDTO();
        [JsonPropertyName("Personal Status")]
        public PersonalStatusDTO PersonalStatus { get; init; } = new PersonalStatusDTO();
        [JsonPropertyName("Zanpakutō")]
        public ZanpakutoDTO Zanoakuto { get; init; } = new ZanpakutoDTO();
    }
}
