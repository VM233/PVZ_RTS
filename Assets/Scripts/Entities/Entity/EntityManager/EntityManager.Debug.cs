#if UNITY_EDITOR
using PVZRTS.Damage;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Core.Linq;
using VMFramework.GameLogicArchitecture;
using VMFramework.OdinExtensions;

namespace PVZRTS.Entities
{
    public partial class EntityManager
    {
        [Button]
        private static void CreateEntity([GamePrefabID(typeof(IEntityConfig))] string id, Vector3 position,
            int count = 1)
        {
            count.Repeat(() =>
            {
                var entity = IGameItem.Create<IEntity>(id);

                CreateEntity(entity, position);
            });
        }

        [Button]
        private static void CreateLinearBullet([GamePrefabID(typeof(ILinearBulletConfig))] string id,
            Vector3 position, DamagePacket damagePacket, Vector3 direction)
        {
            var projectile = IGameItem.Create<ILinearBullet>(id);
            projectile.InitProjectile(damagePacket, direction);
            CreateEntity(projectile, position);
        }
    }
}
#endif