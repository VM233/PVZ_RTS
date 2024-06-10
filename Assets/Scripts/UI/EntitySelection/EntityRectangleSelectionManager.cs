using System;
using System.Linq;
using PVZRTS.Entities;
using PVZRTS.GameCore;
using Sirenix.OdinInspector;
using UnityEngine;
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

        private static float offsetX = 0;
        
        [ShowInInspector]
        private static LineRenderer lineRenderer;
        
        [ShowInInspector]
        private static Material lineMaterial;

        private static readonly int mainTex = Shader.PropertyToID("_MainTex");

        protected override void OnBeforeInit()
        {
            base.OnBeforeInit();

            var selection = Instantiate(GameSetting.entitySelectionGeneralSetting.entitySelectionPrefab);
            
            lineRenderer = selection.GetComponent<LineRenderer>();
            lineMaterial = lineRenderer.material;
            
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
                    var (leftBottom, rightTop) = GetSelectionBox();
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
                
                var (leftBottom, rightTop) = GetSelectionBox();
                leftBottom += new Vector3(0, GameSetting.entitySelectionGeneralSetting.selectionYOffset, 0);
                rightTop += new Vector3(0, GameSetting.entitySelectionGeneralSetting.selectionYOffset, 0);

                lineRenderer.positionCount = 4;
                lineRenderer.SetPosition(0, leftBottom);
                lineRenderer.SetPosition(1, new Vector3(rightTop.x, (leftBottom.y + rightTop.y) / 2, leftBottom.z));
                lineRenderer.SetPosition(2, rightTop);
                lineRenderer.SetPosition(3, new Vector3(leftBottom.x, (leftBottom.y + rightTop.y) / 2, rightTop.z));
                
                lineMaterial.SetTextureOffset(mainTex, new Vector2(offsetX, 0));
                offsetX += Time.deltaTime * GameSetting.entitySelectionGeneralSetting.textureOffsetRollSpeed;
            }
            else
            {
                lineRenderer.enabled = false;
            }
        }

        private static (Vector3 leftBottom, Vector3 rightTop) GetSelectionBox()
        {
            var leftBottom = startPos.Min(endPos);
            var rightTop = startPos.Max(endPos);
            
            return (leftBottom, rightTop);
        }
    }
}