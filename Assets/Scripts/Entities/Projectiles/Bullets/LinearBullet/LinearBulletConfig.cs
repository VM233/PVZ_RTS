using System;

namespace PVZRTS.Entities
{
    public class LinearBulletConfig : BulletConfig, ILinearBulletConfig
    {
        public override Type gameItemType => typeof(LinearBullet);

        protected override Type controllerType => typeof(LinearBulletController);
    }
}