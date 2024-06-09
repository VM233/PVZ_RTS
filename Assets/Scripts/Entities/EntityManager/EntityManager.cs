using FishNet;
using FishNet.Connection;
using FishNet.Object;
using PVZRTS.GameCore;
using UnityEngine;
using VMFramework.Core;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;
using VMFramework.Procedure;

namespace PVZRTS.Entities
{
    [ManagerCreationProvider(nameof(GameManagerType.Entity))]
    public sealed partial class EntityManager : UUIDManager<EntityManager, IEntity>
    {
        #region Create & Destroy

        [Server]
        public static EntityController CreateEntity(IEntity entity, Vector2 position,
            NetworkConnection ownerConnection = null)
        {
            entity.AssertIsNotNull(nameof(entity));
            entity.prefab.AssertIsNotNull(nameof(entity.prefab));

            var gameObject = InstanceFinder.NetworkManager.GetPooledInstantiated(entity.prefab, true);

            gameObject.transform.position = position;

            var entityController = gameObject.GetComponent<EntityController>();

            entityController.Init(entity);

            InstanceFinder.ServerManager.Spawn(gameObject, ownerConnection);

            return entityController;
        }

        [Server]
        public static void DestroyEntity(IEntity entity)
        {
            if (entity == null)
            {
                Debug.LogWarning("Tried to destroy null Entity.");
                return;
            }

            if (UUIDCoreManager.HasUUIDWithWarning(entity.uuid))
            {
                IGameItem.Destroy(entity);

                entity.controller.Hide();

                InstanceFinder.ServerManager.Despawn(entity.controller.gameObject, DespawnType.Pool);
            }
        }

        #endregion
    }
}