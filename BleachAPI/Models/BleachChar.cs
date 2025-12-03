namespace BleachAPI.Models
{
    public class BleachChar
    {
        public Guid Id { get; private set; }
        public string ExternalId { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string NameEnglish { get; private set; } = string.Empty;
        public string NameKanji { get; private set; } = string.Empty;
        public string NameRomaji { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Race { get; private set; } = string.Empty;
        public string Gender { get; private set; } = string.Empty;
        public string Birthday { get; private set; } = string.Empty;
        public string Age { get; private set; } = string.Empty;
        public string Occupation { get; private set; } = string.Empty;
        public string Education { get; private set; } = string.Empty;
        public string Shikai { get; private set; } = string.Empty;
        public string Bankai { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public List<CharAffiliation> Affiliations { get; private set; } = new();
        public List<CharBaseOps> BaseOps { get; private set; } = new();
        public List<CharRelatives> Relatives { get; private set; } = new();

        public BleachChar(BleachAPIModel dto)
        {
            Id = Guid.NewGuid();
            ExternalId = dto.Id;
            Slug = dto.Slug;
            NameEnglish = dto.NameEnglish;
            NameKanji = dto.NameKanji;
            NameRomaji = dto.NameRomaji;
            Description = dto.Description;
            Race = dto.Race;
            Gender = dto.Gender;
            Birthday = dto.Birthday;
            Age = dto.Age;
            Occupation = dto.Occupation;
            Education = dto.Education;
            Shikai = dto.Shikai;
            Bankai = dto.Bankai;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

            foreach (var aff in dto.Affiliation)
                Affiliations.Add(new CharAffiliation(Id, aff, false));

            foreach (var prevAff in dto.PreviousAffiliation)
                Affiliations.Add(new CharAffiliation(Id, prevAff, true));

            foreach (var op in dto.BaseOps)
                BaseOps.Add(new CharBaseOps(Id, op));

            foreach (var rel in dto.Relatives)
                Relatives.Add(new CharRelatives(Id, rel));
        }
    }
}

