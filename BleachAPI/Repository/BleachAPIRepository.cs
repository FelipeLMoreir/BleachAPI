using BleachAPI.DataBase;
using BleachAPI.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Text.Json;

namespace BleachAPI.Repository
{
    public class BleachAPIRepository
    {
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;

        public BleachAPIRepository(IConfiguration config, IHttpClientFactory httpFactory)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("DefaultConnection missing");
            _httpClient = httpFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("https://bleach-api-8v2r.onrender.com/");
        }

        public async Task SaveFromApiAsync(string race, string name)
        {
            using var conn = new SqlConnection(_connectionString);
            await conn.OpenAsync();

            var response = await _httpClient.GetAsync($"characters/{race}/{name}");
            if (!response.IsSuccessStatusCode) return;

            var json = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var serializer = JsonSerializer.Deserialize<CharResults>(json, options);


            var character = serializer?.Results?.FirstOrDefault();
            if (character == null) return;

            using var transaction = await conn.BeginTransactionAsync();
            try
            {
                    var sql = @"
                INSERT INTO BleachCharacter 
                (Id, ExternalId, Slug, NameEnglish, NameKanji, NameRomaji, Description, 
                 Race, Gender, Birthday, Age, Occupation, Education, Shikai, Bankai)
                VALUES (@Id, @ExternalId, @Slug, @NameEnglish, @NameKanji, @NameRomaji, @Description, 
                        @Race, @Gender, @Birthday, @Age, @Occupation, @Education, @Shikai, @Bankai)";

                var parameters = new {
                    Id = Guid.NewGuid(),              
                    ExternalId = character.Id,        
                    character.Slug,
                    character.NameEnglish,
                    character.NameKanji,
                    character.NameRomaji,
                    character.Description,
                    character.Race,
                    character.Gender,
                    character.Birthday,
                    character.Age,
                    character.Occupation,
                    character.Education,
                    character.Shikai,
                    character.Bankai
                };

                await conn.ExecuteAsync(sql, parameters, transaction);

                await transaction.CommitAsync();
            }
            catch { await transaction.RollbackAsync(); throw; }
        }
    }
}
