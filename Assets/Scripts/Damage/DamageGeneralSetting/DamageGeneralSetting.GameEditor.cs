#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Damage
{
    public partial class DamageGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Damage";
    }
}
#endif