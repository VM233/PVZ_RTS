using System;
using System.Collections.Generic;
using FishNet;
using FishNet.Object;
using UnityEngine;
using UnityEngine.Scripting;
using VMFramework.GameLogicArchitecture;
using VMFramework.Procedure;

namespace PVZRTS.Entities
{
    [GameInitializerRegister(ClientRunningProcedure.ID, ProcedureLoadingType.OnEnter)]
    [Preserve]
    public sealed class EntityControllerPoolClientInitializer : IGameInitializer
    {
        private bool hasCached = false;

        IEnumerable<InitializationAction> IInitializer.GetInitializationActions()
        {
            yield return new(InitializationOrder.PostInit, OnPostInit, this);
        }

        private void OnPostInit(Action onDone)
        {
            if (hasCached)
            {
                onDone();
                return;
            }
            
            foreach (var entityConfig in GamePrefabManager.GetAllGamePrefabs<IEntityConfig>())
            {
                if (entityConfig.prefab.TryGetComponent(out NetworkObject networkObject) == false)
                {
                    Debug.LogError(
                        $"Prefab {entityConfig}'s prefab does not have a NetworkObject component.");

                    continue;
                }

                if (entityConfig.prewarmCount <= 0)
                {
                    continue;
                }
                
                InstanceFinder.NetworkManager.CacheObjects(networkObject, entityConfig.prewarmCount, false);
            }
            
            hasCached = true;

            onDone();
        }
    }
}