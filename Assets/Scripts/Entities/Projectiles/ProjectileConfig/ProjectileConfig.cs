using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public abstract class ProjectileConfig : EntityConfig, IProjectileConfig
    {
        protected const string PROJECTILE_CATEGORY = "Projectile";

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        public bool hasMaxDamageCount = true;

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [EnableIf(nameof(hasMaxDamageCount))]
        [MinValue(1)]
        public int maxDamageCount = 1;

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [MinValue(0)]
        public float maxLifeTime = 5;

        #region Interface Implementation

        bool IProjectileConfig.hasMaxDamageCount => hasMaxDamageCount;

        int IProjectileConfig.maxDamageCount => maxDamageCount;

        float IProjectileConfig.maxLifeTime => maxLifeTime;

        #endregion
    }
}