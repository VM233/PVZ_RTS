using System;
using PVZRTS.Properties;

namespace PVZRTS.Entities
{
    public class BulletConfig : EntityConfig, IBulletConfig
    {
        public override Type gameItemType => typeof(Bullet);

        public float defaultSpeed;

        #region Interface Implementation

        float ISpeedOwnerConfig.defaultSpeed => defaultSpeed;

        #endregion
    }
}