using System;
using PVZRTS.Properties;
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
        public int defaultPhysicalDefense = 0;
        
        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0)]
        public int defaultMagicalDefense = 0;

        [TabGroup(TAB_GROUP_NAME, BASIC_CATEGORY)]
        [MinValue(0)]
        public float defaultDefensePercent = 0;

        #region Interface Implementation

        int IHealthOwnerConfig.defaultMaxHealth => defaultMaxHealth;

        int IDefenseOwnerConfig.defaultPhysicalDefense => defaultPhysicalDefense;

        int IDefenseOwnerConfig.defaultMagicalDefense => defaultMagicalDefense;

        float IDefenseOwnerConfig.defaultDefensePercent => defaultDefensePercent;

        #endregion
    }
}