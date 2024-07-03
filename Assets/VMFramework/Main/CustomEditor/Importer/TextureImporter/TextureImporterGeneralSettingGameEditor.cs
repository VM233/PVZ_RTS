#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;
using VMFramework.Localization;

namespace VMFramework.Editor
{
    public partial class TextureImporterGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "Texture Importer";
    }
}
#endif