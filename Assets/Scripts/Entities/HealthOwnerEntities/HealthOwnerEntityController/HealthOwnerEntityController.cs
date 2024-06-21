using FishNet;
using FishNet.Object.Synchronizing;
using PVZRTS.Damage;
using PVZRTS.Properties;
using Sirenix.OdinInspector;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public partial class HealthOwnerEntityController : EntityController, IDamageableController
    {
        public IHealthOwnerEntity healthOwnerEntity => (IHealthOwnerEntity)entity;

        IDamageable IDamageableController.damageable => healthOwnerEntity;

        [ShowInInspector]
        private readonly SyncVar<BaseBoostInt> maxHealthOnServer = new();
        
        [ShowInInspector]
        private readonly SyncVar<int> healthOnServer = new();
        
        [ShowInInspector]
        private readonly SyncVar<BaseBoostInt> physicalDefenseOnServer = new();
        
        [ShowInInspector]
        private readonly SyncVar<BaseBoostInt> magicalDefenseOnServer = new();
        
        [ShowInInspector]
        private readonly SyncVar<float> defensePercentOnServer = new();

        protected override void OnPreInit()
        {
            base.OnPreInit();

            if (InstanceFinder.IsServerStarted)
            {
                healthOwnerEntity.OnMaxHealthChanged += OnMaxHealthChangedOnServer;
                healthOwnerEntity.OnHealthChanged += OnHealthChangedOnServer;
                healthOwnerEntity.OnPhysicalDefenseChanged += OnPhysicalDefenseChangedOnServer;
                healthOwnerEntity.OnMagicalDefenseChanged += OnMagicalDefenseChangedOnServer;
                healthOwnerEntity.OnDefensePercentChanged += OnDefensePercentChangedOnServer;
            }
        }

        protected override void OnDestruct()
        {
            base.OnDestruct();

            if (InstanceFinder.IsServerStarted)
            {
                healthOwnerEntity.OnMaxHealthChanged -= OnMaxHealthChangedOnServer;
                healthOwnerEntity.OnHealthChanged -= OnHealthChangedOnServer;
                healthOwnerEntity.OnPhysicalDefenseChanged -= OnPhysicalDefenseChangedOnServer;
                healthOwnerEntity.OnMagicalDefenseChanged -= OnMagicalDefenseChangedOnServer;
                healthOwnerEntity.OnDefensePercentChanged -= OnDefensePercentChangedOnServer;
            }
        }

        protected virtual void Awake()
        {
            maxHealthOnServer.OnChange += OnMaxHealthOnServerChanged;
            healthOnServer.OnChange += OnHealthOnServerChanged;
            physicalDefenseOnServer.OnChange += OnPhysicalDefenseOnServerChanged;
            magicalDefenseOnServer.OnChange += OnMagicalDefenseOnServerChanged;
            defensePercentOnServer.OnChange += OnDefensePercentOnServerChanged;
        }

        private void OnMaxHealthOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.maxHealthBaseValue = newValue.baseValue;
                healthOwnerEntity.maxHealthBoostValue = newValue.boostValue;
            }
        }
        
        private void OnHealthOnServerChanged(int oldValue, int newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.health = newValue;
            }
        }

        private void OnPhysicalDefenseOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.physicalDefenseBaseValue = newValue.baseValue;
                healthOwnerEntity.physicalDefenseBoostValue = newValue.boostValue;
            }
        }
        
        private void OnMagicalDefenseOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.magicalDefenseBaseValue = newValue.baseValue;
                healthOwnerEntity.magicalDefenseBoostValue = newValue.boostValue;
            }
        }

        private void OnDefensePercentOnServerChanged(float oldValue, float newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.defensePercent = newValue;
            }
        }

        private void OnMaxHealthChangedOnServer(IHealthOwner healthOwner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            maxHealthOnServer.Value = newValue;
        }

        private void OnHealthChangedOnServer(IHealthOwner healthOwner, int oldValue, int newValue)
        {
            healthOnServer.Value = newValue;
        }
        
        private void OnPhysicalDefenseChangedOnServer(IDefenseOwner defenseOwner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            physicalDefenseOnServer.Value = newValue;
        }
        
        private void OnMagicalDefenseChangedOnServer(IDefenseOwner defenseOwner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            magicalDefenseOnServer.Value = newValue;
        }

        private void OnDefensePercentChangedOnServer(IDefenseOwner defenseOwner, float oldValue,
            float newValue)
        {
            defensePercentOnServer.Value = newValue;
        }
    }
}