#if UNITY_EDITOR
using VMFramework.Core.Editor;
using VMFramework.Editor;
using VMFramework.Editor.GameEditor;

namespace PVZRTS.Entities
{
    public partial class EntityConfig : IGameEditorMenuTreeNode
    {
        Icon IGameEditorMenuTreeNode.icon
        {
            get
            {
                if (prefab != null)
                {
                    return prefab.GetAssetPreview();
                }

                return Icon.None;
            }
        }
    }
}
#endif