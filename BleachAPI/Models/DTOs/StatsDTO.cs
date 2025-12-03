using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class StatsDTO
    {
        [JsonPropertyName("race")]
        public string Race { get; init; } = "";

        [JsonPropertyName("gender")]
        public string Gender { get; init; } = "";

        [JsonPropertyName("birthday")]
        public string Birthday { get; init; } = "";

        [JsonPropertyName("age")]
        public string Age { get; init; } = "";

        [JsonPropertyName("Professional Status")]
        public ProfessionalStatusDTO ProfessionalStatus { get; init; } = new();

        [JsonPropertyName("Personal Status")]
        public PersonalStatusDTO PersonalStatus { get; init; } = new();

        [JsonPropertyName("Zanpakutō")]
        public ZanpakutoDTO Zanpakuto { get; init; } = new();
    }
}
