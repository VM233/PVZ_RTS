using System;
using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public class HealthOwnerEntityConfig : EntityConfig, IHealthOwnerEntityConfig
    {
        public override Type gameItemType => typeof(HealthOwnerEntity);

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0)]
        public int defaultMaxHealth = 20;

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0)]
        public int defaultDefense = 0;

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0)]
        public float defaultDefensePercent = 0;

        #region Interface Implementation

        int IHealthOwnerEntityConfig.defaultMaxHealth => defaultMaxHealth;

        int IHealthOwnerEntityConfig.defaultDefense => defaultDefense;
        
        float IHealthOwnerEntityConfig.defaultDefensePercent => defaultDefensePercent;

        #endregion
    }
}