﻿#if UNITY_EDITOR && ODIN_INSPECTOR
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using VMFramework.Core.Editor;
using VMFramework.Core.Linq;
using VMFramework.Editor;
using VMFramework.GameLogicArchitecture;
using VMFramework.GameLogicArchitecture.Editor;

namespace VMFramework.OdinExtensions
{
    internal sealed class GamePrefabWrapperContextMenuDrawer : OdinValueDrawer<GamePrefabWrapper>, IDefinesGenericMenuItems
    {
        private static readonly List<IGamePrefab> gamePrefabsCache = new();
        
        protected override void DrawPropertyLayout(GUIContent label)
        {
            CallNextDrawer(label);
        }

        void IDefinesGenericMenuItems.PopulateGenericMenu(InspectorProperty property, GenericMenu genericMenu)
        {
            var value = ValueEntry.SmartValue;
        
            gamePrefabsCache.Clear();
            gamePrefabsCache.AddRange(value.GetGamePrefabs());

            if (gamePrefabsCache.IsNullOrEmptyOrAllNull())
            {
                return;
            } 
                
            genericMenu.AddItem(EditorNames.OPEN_GAME_PREFAB_SCRIPT_PATH, value.OpenGamePrefabScripts);

            if (gamePrefabsCache.Any(gamePrefab => gamePrefab.gameItemType != null))
            {
                genericMenu.AddItem(EditorNames.OPEN_GAME_ITEM_SCRIPT_PATH, value.OpenGameItemScripts);
            }
        }
    }
}
#endif