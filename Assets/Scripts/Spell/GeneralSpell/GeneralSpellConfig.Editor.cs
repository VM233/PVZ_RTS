#if UNITY_EDITOR
namespace TH.Spells
{
    public partial class GeneralSpellConfig
    {
        protected override void OnInspectorInit()
        {
            base.OnInspectorInit();

            spellUnitsID ??= new();
        }
    }
}
#endif