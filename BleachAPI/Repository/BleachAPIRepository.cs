using BleachAPI.DataBase;
using BleachAPI.Models;
using BleachAPI.Models.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Text.Json;

namespace BleachAPI.Repository
{
    public class BleachAPIRepository
    {
        private readonly string _connectionString;
        private readonly HttpClient _httpClient;

        public BleachAPIRepository(IConfiguration config, IHttpClientFactory httpFactory)
        {
            _connectionString = config.GetConnectionString("DefaultConnection")!;
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
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var deserializer = JsonSerializer.Deserialize<CharacterResponseDTO>(json, options);

            var character = deserializer?.Results?.FirstOrDefault();
            if (character == null) return;

            using var transaction = await conn.BeginTransactionAsync();
            try
            {
                var characterId = await conn.QueryFirstOrDefaultAsync<Guid?>(@"
            SELECT Id FROM BleachCharacter WHERE ExternalId = @ExternalId",
                    new { ExternalId = character.Id }, transaction);

                Guid actualId;
                if (!characterId.HasValue)
                {
                    actualId = Guid.NewGuid();

                    await conn.ExecuteAsync(@"
                INSERT INTO BleachCharacter (Id, ExternalId, Slug, NameEnglish, NameKanji, NameRomaji, 
                    Description, Race, Gender, Birthday, Age, Occupation, Education, Shikai, Bankai)
                VALUES (@Id, @ExternalId, @Slug, @NameEnglish, @NameKanji, @NameRomaji, 
                        @Description, @Race, @Gender, @Birthday, @Age, @Occupation, 
                        @Education, @Shikai, @Bankai)",
                        new
                        {
                            Id = actualId,
                            ExternalId = character.Id,
                            Slug = character.Slug,
                            NameEnglish = character.Name.English,
                            NameKanji = character.Name.Kanji,
                            NameRomaji = character.Name.Romaji,
                            Description = character.Description,
                            Race = character.Stats.Race,
                            Gender = character.Stats.Gender,
                            Birthday = character.Stats.Birthday,
                            Age = character.Stats.Age,
                            Occupation = character.Stats.ProfessionalStatus.Occupation,
                            Education = character.Stats.PersonalStatus.Education,
                            Shikai = character.Stats.Zanpakuto.Shikai,
                            Bankai = character.Stats.Zanpakuto.Bankai
                        }, transaction);
                }
                else
                {
                    actualId = characterId.Value;

                    await conn.ExecuteAsync(@"
                UPDATE BleachCharacter SET Slug=@Slug, NameEnglish=@NameEnglish, NameKanji=@NameKanji, 
                    NameRomaji=@NameRomaji, Description=@Description, Race=@Race, Gender=@Gender, 
                    Birthday=@Birthday, Age=@Age, Occupation=@Occupation, Education=@Education, 
                    Shikai=@Shikai, Bankai=@Bankai 
                WHERE Id = @Id",
                        new
                        {
                            Id = actualId,
                            Slug = character.Slug,
                            NameEnglish = character.Name.English,
                            NameKanji = character.Name.Kanji,
                            NameRomaji = character.Name.Romaji,
                            Description = character.Description,
                            Race = character.Stats.Race,
                            Gender = character.Stats.Gender,
                            Birthday = character.Stats.Birthday,
                            Age = character.Stats.Age,
                            Occupation = character.Stats.ProfessionalStatus.Occupation,
                            Education = character.Stats.PersonalStatus.Education,
                            Shikai = character.Stats.Zanpakuto.Shikai,
                            Bankai = character.Stats.Zanpakuto.Bankai
                        }, transaction);
                }

                await conn.ExecuteAsync("DELETE FROM CharacterAffiliation WHERE CharacterId = @Id", new { Id = actualId }, transaction);
                await conn.ExecuteAsync("DELETE FROM CharacterBaseOps WHERE CharacterId = @Id", new { Id = actualId }, transaction);
                await conn.ExecuteAsync("DELETE FROM CharacterRelative WHERE CharacterId = @Id", new { Id = actualId }, transaction);

                await InsertList(conn, "CharacterAffiliation", actualId.ToString(), 
                    character.Stats.ProfessionalStatus.Affiliation, "AffiliationName", (SqlTransaction)transaction, false);
                await InsertList(conn, "CharacterAffiliation", actualId.ToString(), 
                    character.Stats.ProfessionalStatus.PreviousAffiliation, "AffiliationName", (SqlTransaction)transaction, true);
                await InsertList(conn, "CharacterBaseOps", actualId.ToString(), 
                    character.Stats.ProfessionalStatus.BaseOfOperations, "BaseOpName", (SqlTransaction)transaction);
                await InsertList(conn, "CharacterRelative", actualId.ToString(), 
                    character.Stats.PersonalStatus.Relatives, "RelativeName", (SqlTransaction)transaction);

                await transaction.CommitAsync();
            }
            catch { await transaction.RollbackAsync(); throw; }
        }

        private async Task InsertList(SqlConnection conn, string tableName, string charId,
            List<string> items, string columnName, SqlTransaction transaction, bool isPreviousAffiliation = false)
        {
            if (!items.Any()) return;

            var data = items.Select(item => new
            {
                Id = Guid.NewGuid(),
                CharacterId = Guid.Parse(charId),  
                Value = item,
                IsPrevious = isPreviousAffiliation
            });

            string sql = tableName == "CharacterAffiliation"
                ? "INSERT INTO CharacterAffiliation (Id, CharacterId, AffiliationName, IsPrevious) VALUES (@Id, @CharacterId, @Value, @IsPrevious)"
                : $"INSERT INTO {tableName} (Id, CharacterId, {columnName}) VALUES (@Id, @CharacterId, @Value)";

            await conn.ExecuteAsync(sql, data, transaction);
        }
    }
}
