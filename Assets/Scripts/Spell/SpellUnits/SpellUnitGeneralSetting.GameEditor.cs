#if UNITY_EDITOR
using PVZRTS.GameCore;
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public partial class SpellUnitGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Spell Unit";

        IGameEditorMenuTreeNode IGameEditorMenuTreeNode.parentNode => GameSetting.spellGeneralSetting;
    }
}
#endif