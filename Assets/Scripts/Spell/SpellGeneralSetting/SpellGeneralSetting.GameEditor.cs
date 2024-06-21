#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public partial class SpellGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Spell";
    }
}
#endif