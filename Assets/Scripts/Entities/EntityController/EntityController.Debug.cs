#if UNITY_EDITOR
using FishNet.Object;
using Sirenix.OdinInspector;

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
    }
}
#endif