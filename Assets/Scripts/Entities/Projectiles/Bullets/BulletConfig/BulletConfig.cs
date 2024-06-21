using System;
using PVZRTS.Properties;
using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public abstract class BulletConfig : ProjectileConfig, IBulletConfig
    {
        public override Type gameItemType => typeof(Bullet);

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        public float defaultSpeed;

        #region Interface Implementation

        float ISpeedOwnerConfig.defaultSpeed => defaultSpeed;

        #endregion
    }
}