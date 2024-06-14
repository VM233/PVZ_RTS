namespace PVZRTS.Entities
{
    public interface ICreatureConfig : IHealthOwnerEntityConfig
    {
        public int defaultPhysicalAttack { get; }
        
        public int defaultMagicalAttack { get; }
        
        public float defaultCriticalRate { get; }
        
        public float defaultCriticalDamageMultiplier { get; }
    }
}