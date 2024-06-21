using System;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.OdinExtensions;

namespace PVZRTS.Entities
{
    public partial class EntityConfig : DescribedGamePrefab, IEntityConfig
    {
        public override Type gameItemType => typeof(Entity);

        protected sealed override string idSuffix => "entity";
        
        protected virtual Type controllerType => typeof(EntityController);

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0), MaxValue(100)]
        public int prewarmCount = 0;

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [Required, RequiredComponent(nameof(controllerType)), AssetsOnly]
        public GameObject prefab;

        #region Interface Implementation

        int IEntityConfig.prewarmCount => prewarmCount;

        GameObject IEntityConfig.prefab => prefab;

        #endregion
    }
}