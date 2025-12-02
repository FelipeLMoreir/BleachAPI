using BleachAPI.Models;
using BleachAPI.Models.DTOs;
using System.Text.Json;

namespace BleachAPI.Services
{
    public class BleachAPIService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _options = 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        public BleachAPIService(HttpClient client)
        {
            _client = client; 
        }
        public async Task<CharacterDTO?> GetCharacterByRaceAndNameAsync (string race, string name)
        {
            var url = $"characters/{race}/{name}";
            var response = await _client.GetAsync(url);

            if (!response.IsSuccessStatusCode) return null;

            var json = await response.Content.ReadAsStringAsync();
            var deserializer = JsonSerializer.Deserialize<CharacterResponseDTO>(json, _options);
            return deserializer?.Results?.FirstOrDefault();
        }
    }
}
