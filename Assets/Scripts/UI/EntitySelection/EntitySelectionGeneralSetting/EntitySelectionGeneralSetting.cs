﻿using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.OdinExtensions;

namespace PVZRTS.UI
{
    public sealed partial class EntitySelectionGeneralSetting : GeneralSetting
    {
        [Required]
        public GameObject entitySelectionPrefab;
        
        public float selectionYOffset = 0.5f;
        
        public float textureOffsetRollSpeed = 0.5f;

        [Layer]
        public int terrainLayer;
    }
}