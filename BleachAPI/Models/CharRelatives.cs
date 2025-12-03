namespace BleachAPI.Models
{
    public class CharRelatives
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string RelativeName { get; private set; } = string.Empty;

        public CharRelatives(Guid characterId, string name)
        {
            Id = Guid.NewGuid();
            CharacterId = characterId;
            RelativeName = name;
        }
    }
}
