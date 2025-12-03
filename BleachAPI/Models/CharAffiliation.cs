namespace BleachAPI.Models
{
    public class CharAffiliation
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string AffiliationName { get; private set; } = string.Empty;
        public bool IsPrevious { get; private set; }

        public CharAffiliation(Guid characterId, string name, bool isPrevious)
        {
            Id = Guid.NewGuid();
            CharacterId = characterId;
            AffiliationName = name;
            IsPrevious = isPrevious;
        }
    }
}
