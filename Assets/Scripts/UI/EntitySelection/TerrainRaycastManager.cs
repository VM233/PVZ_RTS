using System.Runtime.CompilerServices;
using PVZRTS.GameCore;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Cameras;
using VMFramework.Core;
using VMFramework.Procedure;

namespace PVZRTS.UI
{
    [ManagerCreationProvider(nameof(GameManagerType.UI))]
    public sealed class TerrainRaycastManager : ManagerBehaviour<TerrainRaycastManager>
    {
        [ShowInInspector]
        [HideInEditorMode]
        private static Vector3 position
        {
            get
            {
                if (Application.isPlaying == false)
                {
                    return default;
                }
                
                return TryGetMousePositionOnTerrain(out var pos) ? pos : default;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryGetMousePositionOnTerrain(out Vector3 position)
        {
            Vector3 mousePos = Input.mousePosition;

            if (mousePos.IsInfinity())
            {
                position = default;
                return false;
            }
            
            Ray ray = CameraManager.mainCamera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out var hit, 1000f,
                    GameSetting.entitySelectionGeneralSetting.terrainLayer.ToLayerMaskInt()) == false)
            {
                position = default;
                return false;
            }
            
            position = hit.point;
            return true;
        }
    }
}