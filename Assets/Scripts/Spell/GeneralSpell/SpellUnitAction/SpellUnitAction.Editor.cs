#if UNITY_EDITOR
using Sirenix.OdinInspector;
using VMFramework.Core.Editor;

namespace TH.Spells
{
    public partial class SpellUnitAction
    {
        [Button]
        private void OpenScript()
        {
            GetType().OpenScriptOfType();
        }
    }
}
#endif