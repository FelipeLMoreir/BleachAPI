using BleachAPI.Models.DTOs;
using System.Text.Json.Serialization;

namespace BleachAPI.Models
{
    public class BleachAPIModel
    {
        [JsonPropertyName("id")]
        public string Id { get;  set; }
        [JsonPropertyName("slug")]
        public string Slug { get;  set; }
        [JsonPropertyName("english")]
        public string NameEnglish { get;  set; }
        [JsonPropertyName("kanji")]
        public string NameKanji { get;  set; }
        [JsonPropertyName("romaji")]
        public string NameRomaji { get;  set; }
        [JsonPropertyName("description")]
        public string Description { get;  set; }
        [JsonPropertyName("race")]
        public string Race { get;  set; }
        [JsonPropertyName("gender")]
        public string Gender { get;  set; }
        [JsonPropertyName("birthday")]
        public string Birthday { get;  set; }
        [JsonPropertyName("age")]
        public string Age { get;  set; }
        [JsonPropertyName("affiliation")]
        public List<string> Affiliation { get; set; }
        [JsonPropertyName("previous affiliation")]
        public List<string> PreviousAffiliation { get; set; }
        [JsonPropertyName("occupation")]
        public string Occupation { get; set; }
        [JsonPropertyName("base of operations")]
        public List<string> BaseOps { get; set; }
        [JsonPropertyName("relatives")]
        public List<string> Relatives { get; set; }
        [JsonPropertyName("education")]
        public string Education { get; set; }
        [JsonPropertyName("shikai")]
        public string Shikai { get; set; }
        [JsonPropertyName("bankai")]
        public string Bankai { get; set; }

        public BleachAPIModel()
        {
            
        }

        public BleachAPIModel(
            string id,
            string slug,
            NameDTO name,
            StatsDTO stats,
            string description,
            ProfessionalStatusDTO professional,
            PersonalStatusDTO personal,
            ZanpakutoDTO zanpakuto
            )
        {
            this.Id = id;
            this.Slug = slug;
            this.NameEnglish = name.NameEnglish;
            this.NameKanji = name.NameKanji;
            this.NameRomaji = name.NameRomaji;
            this.Description = description;
            this.Race = stats.Race;
            this.Gender = stats.Gender;
            this.Age = stats.Age;
            this.Birthday = stats.Birthday;
            this.Affiliation = professional.Affiliation;
            this.PreviousAffiliation = professional.PreviousAffiliation;
            this.Occupation = professional.Occupation;
            this.BaseOps = professional.BaseOps;
            this.Relatives = personal.Relatives;
            this.Education = personal.Education;
            this.Shikai = zanpakuto.Shikai;
            this.Bankai = zanpakuto.Bankai;
        }
    }
}
