using PVZRTS.Properties;
using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public class MoveableCreatureConfig : CreatureConfig, IMoveableCreatureConfig
    {
        [TabGroup(TAB_GROUP_NAME, CREATURE_CATEGORY)]
        public float defaultSpeed;

        #region Interface Implementation

        float ISpeedOwnerConfig.defaultSpeed => defaultSpeed;

        #endregion
    }
}