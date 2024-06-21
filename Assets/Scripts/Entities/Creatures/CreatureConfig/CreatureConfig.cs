using System;
using PVZRTS.Properties;
using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public class CreatureConfig : HealthOwnerEntityConfig, ICreatureConfig
    {
        public override Type gameItemType => typeof(Creature);

        protected override Type controllerType => typeof(CreatureController);

        protected const string CREATURE_CATEGORY = "Creature";

        [TabGroup(TAB_GROUP_NAME, CREATURE_CATEGORY)]
        [MinValue(0)]
        public int defaultPhysicalAttack;

        [TabGroup(TAB_GROUP_NAME, CREATURE_CATEGORY)]
        [MinValue(0)]
        public int defaultMagicalAttack;

        [TabGroup(TAB_GROUP_NAME, CREATURE_CATEGORY)]
        [MinValue(0)]
        public float defaultCriticalRate = 0;
        
        [TabGroup(TAB_GROUP_NAME, CREATURE_CATEGORY)]
        [MinValue(0)]
        public float defaultCriticalDamageMultiplier = 1;

        #region Interface Implementation

        int IAttackOwnerConfig.defaultPhysicalAttack => defaultPhysicalAttack;

        int IAttackOwnerConfig.defaultMagicalAttack => defaultMagicalAttack;

        float IAttackOwnerConfig.defaultCriticalRate => defaultCriticalRate;

        float IAttackOwnerConfig.defaultCriticalDamageMultiplier => defaultCriticalDamageMultiplier;

        #endregion
    }
}