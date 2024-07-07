#if UNITY_EDITOR
using VMFramework.Configuration;

namespace TH.Spells
{
    public partial class ProjectileSpellUnitConfig
    {
        protected override void OnInspectorInit()
        {
            base.OnInspectorInit();

            scatterAngle ??= new SingleVectorChooserConfig<float>(30f);
            numbers ??= new SingleVectorChooserConfig<int>(1);
            shootingInterval ??= new SingleVectorChooserConfig<float>(0f);
            delay ??= new SingleVectorChooserConfig<float>(0);

            physicalAttack ??= new SingleVectorChooserConfig<int>(1);
            magicalAttack ??= new SingleVectorChooserConfig<int>(0);
        }
    }
}
#endif