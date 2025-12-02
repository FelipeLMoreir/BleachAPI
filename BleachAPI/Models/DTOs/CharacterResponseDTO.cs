using System.Text.Json.Serialization;

namespace BleachAPI.Models.DTOs
{
    public class CharacterResponseDTO
    {
        [JsonPropertyName("results")]
        public List<CharacterDTO> Results { get; init; } = [];
    }
}
