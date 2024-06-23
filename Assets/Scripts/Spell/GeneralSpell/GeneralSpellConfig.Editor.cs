#if UNITY_EDITOR
namespace TH.Spells
{
    public partial class GeneralSpellConfig
    {
        protected override void OnInspectorInit()
        {
            base.OnInspectorInit();

            spellUnitActions ??= new();
        }
    }
}
#endif