namespace PVZRTS.Properties
{
    public interface IAttackOwnerConfig
    {
        public int defaultPhysicalAttack { get; }
        
        public int defaultMagicalAttack { get; }
        
        public float defaultCriticalRate { get; }
        
        public float defaultCriticalDamageMultiplier { get; }
    }
}