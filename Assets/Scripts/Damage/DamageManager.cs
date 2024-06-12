using PVZRTS.Entities;
using PVZRTS.GameCore;
using Sirenix.OdinInspector;
using VMFramework.Procedure;

namespace PVZRTS.Damage
{
    [ManagerCreationProvider(nameof(GameManagerType.Damage))]
    public class DamageManager : ManagerBehaviour<DamageManager>
    {
        #region Debug

        [Button]
        public static void TakeDamageTo(EntityController source, EntityController target)
        {
            if (source.entity is IDamageSource damageSource)
            {
                damageSource.ForceTakeDamage(target.entity as IDamageable);
            }
        }

        #endregion
    }
}
