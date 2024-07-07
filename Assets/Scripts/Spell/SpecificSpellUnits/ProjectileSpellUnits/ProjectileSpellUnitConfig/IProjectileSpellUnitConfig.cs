using VMFramework.Core;

namespace TH.Spells
{
    public interface IProjectileSpellUnitConfig : ISpellUnitConfig
    {
        public ProjectileDirectionRotationType directionRotationType { get; }
        
        public IChooser<float> scatterAngle { get; }

        public bool shuffleProjectiles { get; }

        public IChooser<int> numbers { get; }

        public IChooser<float> shootingInterval { get; }

        public ProjectileSpawnPosition projectileSpawnPosition { get; }

        public IChooser<float> delay { get; }
        
        public bool isMelee { get; }
        
        public IChooser<int> physicalAttack { get; }

        public IChooser<int> magicalAttack { get; }
    }
}