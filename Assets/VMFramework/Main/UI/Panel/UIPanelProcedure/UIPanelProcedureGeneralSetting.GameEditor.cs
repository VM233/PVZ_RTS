﻿#if UNITY_EDITOR
using VMFramework.Editor.GameEditor;
using VMFramework.GameLogicArchitecture;

namespace VMFramework.UI
{
    public partial class UIPanelProcedureGeneralSetting : IGameEditorMenuTreeNode
    {
        string INameOwner.name => "UI Procedure";
    }
}
#endif