using BleachAPI.Models.DTOs;
using System.Text.Json.Serialization;

namespace BleachAPI.Models
{
    public class BleachAPIModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = "";

        [JsonPropertyName("slug")]
        public string Slug { get; set; } = "";

        [JsonPropertyName("name")]
        public NameDTO Name { get; set; } = new();

        [JsonPropertyName("description")]
        public string Description { get; set; } = "";

        [JsonPropertyName("stats")]
        public StatsDTO Stats { get; set; } = new();
    }
}
