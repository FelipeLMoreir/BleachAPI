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
    }
}

