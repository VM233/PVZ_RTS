using System;
using FishNet.Object.Synchronizing;
using PVZRTS.Damage;
using PVZRTS.Properties;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public partial class HealthOwnerEntityController : EntityController
    {
        public IHealthOwnerEntity healthOwnerEntity => (IHealthOwnerEntity)entity;

        private readonly SyncVar<BaseBoostInt> maxHealthOnServer = new();
        
        private readonly SyncVar<int> healthOnServer = new();
        
        private readonly SyncVar<BaseBoostInt> defenseOnServer = new();
        
        private readonly SyncVar<float> defensePercentOnServer = new();

        protected override void OnPreInit()
        {
            base.OnPreInit();
            
            healthOwnerEntity.OnMaxHealthChanged += OnMaxHealthChangedOnServer;
            healthOwnerEntity.OnHealthChanged += OnHealthChangedOnServer;
            healthOwnerEntity.OnDefenseChanged += OnDefenseChangedOnServer;
            healthOwnerEntity.OnDefensePercentChanged += OnDefensePercentChangedOnServer;
        }

        private void Awake()
        {
            maxHealthOnServer.OnChange += OnMaxHealthOnServerChanged;
            healthOnServer.OnChange += OnHealthOnServerChanged;
            defenseOnServer.OnChange += OnDefenseOnServerChanged;
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

        private void OnDefenseOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue, bool asServer)
        {
            if (asServer == false && IsClientOnlyStarted)
            {
                healthOwnerEntity.defenseBaseValue = newValue.baseValue;
                healthOwnerEntity.defenseBoostValue = newValue.boostValue;
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
        
        private void OnDefenseChangedOnServer(IDefenseOwner defenseOwner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            defenseOnServer.Value = newValue;
        }

        private void OnDefensePercentChangedOnServer(IDefenseOwner defenseOwner, float oldValue,
            float newValue)
        {
            defensePercentOnServer.Value = newValue;
        }
    }
}