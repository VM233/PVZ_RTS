using System.Collections.Generic;
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
        // private static readonly List<IEntity> entitiesToDestroy = new();

        protected override void OnBeforeInitStart()
        {
            base.OnBeforeInitStart();
            
            // InstanceFinder.TimeManager.OnTick += OnTick;
        }

        [Server]
        public static EntityController CreateEntity(IEntity entity, Vector3 position,
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
            // if (entity == null)
            // {
            //     Debug.LogWarning("Tried to destroy null Entity.");
            //     return;
            // }
            //
            // entitiesToDestroy.Add(entity);
            DestroyEntityImmediately(entity);
        }

        [Server]
        public static void DestroyEntityImmediately(IEntity entity)
        {
            if (UUIDCoreManager.HasUUIDWithWarning(entity.uuid))
            {
                // IGameItem.Destroy(entity);

                entity.controller.Hide();

                InstanceFinder.ServerManager.Despawn(entity.controller.gameObject, DespawnType.Pool);
            }
        }

        // private static void OnTick()
        // {
        //     if (entitiesToDestroy.Count > 0)
        //     {
        //         foreach (var entity in entitiesToDestroy)
        //         {
        //             DestroyEntityImmediately(entity);
        //         }
        //         
        //         entitiesToDestroy.Clear();
        //     }
        // }
    }
}