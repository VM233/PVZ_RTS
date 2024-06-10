#if UNITY_EDITOR
using VMFramework.Core.Editor;
using VMFramework.Editor;
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.UI
{
    public partial class EntitySelectionGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "实体选择";

        Icon IGameEditorMenuTreeNode.icon => entitySelectionPrefab.GetAssetPreview();
    }
}
#endif