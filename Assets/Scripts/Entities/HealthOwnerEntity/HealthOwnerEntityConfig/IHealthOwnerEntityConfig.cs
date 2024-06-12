namespace PVZRTS.Entities
{
    public interface IHealthOwnerEntityConfig : IEntityConfig
    {
        public int defaultMaxHealth { get; }
        
        public int defaultDefense { get; }
        
        public float defaultDefensePercent { get; }
    }
}