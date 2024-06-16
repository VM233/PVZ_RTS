using System;
using System.Linq;
using PVZRTS.Entities;
using PVZRTS.GameCore;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using VMFramework.Core;
using VMFramework.Procedure;
using VMFramework.Timers;

namespace PVZRTS.UI
{
    [ManagerCreationProvider(nameof(GameManagerType.UI))]
    public sealed class EntityRectangleSelectionManager : ManagerBehaviour<EntityRectangleSelectionManager>
    {
        private static bool isSelecting = false;
        
        private static Vector3 startPos;
        private static Vector3 endPos;
        
        [SerializeField]
        private LineRenderer lineRenderer;

        [SerializeField]
        private Camera renderCamera;
        
        [SerializeField]
        private DecalProjector decalProjector;

        protected override void OnBeforeInit()
        {
            base.OnBeforeInit();
            
            lineRenderer.positionCount = 4;
            
            UpdateDelegateManager.AddUpdateDelegate(UpdateType.Update, _Update);
        }

        private void _Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TerrainRaycastManager.TryGetMousePositionOnTerrain(out var position))
                {
                    isSelecting = true;
                    startPos = position;
                    endPos = position;
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if (isSelecting)
                {
                    if (TerrainRaycastManager.TryGetMousePositionOnTerrain(out var position))
                    {
                        endPos = position;
                    }
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (isSelecting)
                {
                    var leftBottom = startPos.Min(endPos);
                    var rightTop = startPos.Max(endPos);
                    var center = (leftBottom + rightTop) / 2;
                    var extents = (rightTop - leftBottom) / 2;
                    extents.y += 10f;
                    var hits = Physics.BoxCastAll(center, extents, Vector3.up);

                    var selectedEntities = hits.Select(hit =>
                    {
                        if (hit.transform.TryGetComponent(out EntityController entityController))
                        {
                            return entityController.entity;
                        }
                        
                        return null;
                    }).Where(entity => entity!= null);
                    
                    EntitySelectionManager.Select(selectedEntities);
                }
                
                isSelecting = false;
            }

            if (isSelecting)
            {
                lineRenderer.enabled = true;
                
                var size = (startPos - endPos).Abs().XZ();
                var extents = size / 2;
                var center = (startPos + endPos) / 2;
                var maxSize = size.Max();
                
                var leftBottom = new Vector3(-extents.x, 0, -extents.y);
                var leftTop = new Vector3(-extents.x, 0, extents.y);
                var rightBottom = new Vector3(extents.x, 0, -extents.y);
                var rightTop = new Vector3(extents.x, 0, extents.y);
                
                lineRenderer.SetPosition(0, leftBottom);
                lineRenderer.SetPosition(1, rightBottom);
                lineRenderer.SetPosition(2, rightTop);
                lineRenderer.SetPosition(3, leftTop);

                renderCamera.orthographicSize = extents.Max() + 0.05f;
                decalProjector.size = new Vector3(maxSize, maxSize, 10);
                decalProjector.transform.position = center;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }
    }
}