using Cysharp.Threading.Tasks;
using FishNet.Connection;
using FishNet.Object;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Core;
using VMFramework.GameLogicArchitecture;
using VMFramework.UI;

namespace PVZRTS.Entities
{
    public partial class EntityController : NetworkBehaviour, IEntityController, ITooltipProviderController
    {
        [ShowInInspector]
        public IEntity entity { get; private set; }
        
        [field: Required]
        [field: SerializeField]
        public Transform graphicsTransform { get; private set; }

        public ITooltipProvider provider => entity;

        #region Init & Destroy RPC

        public override void OnSpawnServer(NetworkConnection connection)
        {
            base.OnSpawnServer(connection);
            
            InitOnClient(connection, entity);
        }

        // public override void OnDespawnServer(NetworkConnection connection)
        // {
        //     base.OnDespawnServer(connection);
        //     
        //     DestroyOnClient(connection);
        // }
        
        [TargetRpc(ExcludeServer = true)]
        private void InitOnClient(NetworkConnection connection, IEntity entity)
        {
            Init(entity);
        }
        
        // [TargetRpc(ExcludeServer = true)]
        // private void DestroyOnClient(NetworkConnection connection)
        // {
        //     OnDestruct();
        //     IGameItem.Destroy(entity);
        // }

        #endregion

        #region Destruction

        public override void OnStopNetwork()
        {
            base.OnStopNetwork();

            if (entity is { isDestroyed: false })
            {
                IGameItem.Destroy(entity);
                OnDestruct();
                entity = null;
            }
        }

        protected virtual void OnDestruct()
        {
            
        }

        #endregion

        #region Init

        public async void Init(IEntity entity)
        {
            this.entity = entity;

            OnPreInit();
            
            entity.Init(this);

            await UniTask.WaitUntil(() => IsNetworked);
            
            OnPostInit();
            
            Show();
        }

        protected virtual void OnPreInit()
        {
            
        }

        protected virtual void OnPostInit()
        {

        }

        #endregion
        
        #region Show & Hide

        public virtual void Show()
        {
            if (graphicsTransform != null)
            {
                graphicsTransform.SetActive(true);
            }
        }

        public virtual void Hide()
        {
            if (graphicsTransform != null)
            {
                graphicsTransform.SetActive(false);
            }
        }

        #endregion
    }
}