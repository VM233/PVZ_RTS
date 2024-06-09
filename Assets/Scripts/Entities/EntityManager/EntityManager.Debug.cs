#if UNITY_EDITOR
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
        private static void CreateEntity([GamePrefabID(typeof(IEntityConfig))] string id, Vector2 position,
            int count = 1)
        {
            count.Repeat(() =>
            {
                var entity = IGameItem.Create<IEntity>(id);

                CreateEntity(entity, position);
            });
        }
    }
}
#endif