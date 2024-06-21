namespace PVZRTS.Properties
{
    public interface IDefenseOwnerConfig
    {
        public int defaultPhysicalDefense { get; }
        
        public int defaultMagicalDefense { get; }
        
        public float defaultDefensePercent { get; }
    }
}