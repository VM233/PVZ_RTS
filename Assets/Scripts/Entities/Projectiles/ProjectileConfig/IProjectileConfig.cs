namespace PVZRTS.Entities
{
    public interface IProjectileConfig : IEntityConfig
    {
        public bool hasMaxDamageCount { get; }

        public int maxDamageCount { get; }

        public float maxLifeTime { get; }
    }
}