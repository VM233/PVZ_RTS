using PVZRTS.Entities;
using VMFramework.Configuration;

namespace TH.Spells
{
    public partial class LinearBulletSpellUnitConfig
    {
        protected override void OnInspectorInit()
        {
            base.OnInspectorInit();

            linearProjectileID ??= new SingleGamePrefabIDChooserValue<ILinearBulletConfig>();
        }
    }
}