#if UNITY_EDITOR
using FishNet.Object;
using Sirenix.OdinInspector;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public partial class EntityController
    {
        [Button]
        [Server]
        private void DestroyThisEntity()
        {
            EntityManager.DestroyEntity(entity);
        }

        [Button]
        [Server]
        private void DuplicateThisEntity()
        {
            var newEntity = entity.GetClone();
            
            EntityManager.CreateEntity(newEntity, transform.position);
        }
    }
}
#endif