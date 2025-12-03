namespace BleachAPI.Models
{
    public class CharBaseOps
    {
        public Guid Id { get; private set; }
        public Guid CharacterId { get; private set; }
        public string BaseOpName { get; private set; } = string.Empty;

        public CharBaseOps(Guid characterId, string name)
        {
            Id = Guid.NewGuid();
            CharacterId = characterId;
            BaseOpName = name;
        }
    }
}
