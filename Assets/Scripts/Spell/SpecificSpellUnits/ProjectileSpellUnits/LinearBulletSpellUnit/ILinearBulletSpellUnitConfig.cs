using VMFramework.Core;

namespace TH.Spells
{
    public interface ILinearBulletSpellUnitConfig : IBulletSpellUnitConfig
    {
        public IChooser<string> linearProjectileID { get; }
    }
}