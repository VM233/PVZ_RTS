#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public partial class EntityGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Entity";
    }
}
#endif