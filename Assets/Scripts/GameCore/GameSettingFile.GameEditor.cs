#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.GameCore
{
    public partial class GameSettingFile : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Game Settings";
    }
}
#endif