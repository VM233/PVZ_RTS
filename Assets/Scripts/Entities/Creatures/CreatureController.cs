using FishNet;
using FishNet.Object.Synchronizing;
using PVZRTS.Properties;
using Sirenix.OdinInspector;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public class CreatureController : HealthOwnerEntityController
    {
        public ICreature creature => (ICreature)entity;

        [ShowInInspector]
        private readonly SyncVar<BaseBoostInt> physicalAttackOnServer = new();

        [ShowInInspector]
        private readonly SyncVar<BaseBoostInt> magicalAttackOnServer = new();

        [ShowInInspector]
        private readonly SyncVar<float> criticalRateOnServer = new();

        [ShowInInspector]
        private readonly SyncVar<float> criticalDamageMultiplierOnServer = new();

        protected override void OnPreInit()
        {
            base.OnPreInit();

            if (InstanceFinder.IsServerStarted)
            {
                creature.OnPhysicalAttackChanged += OnPhysicalAttackChangedOnServer;
                creature.OnMagicalAttackChanged += OnMagicalAttackChangedOnServer;
                creature.OnCriticalRateChanged += OnCriticalRateChangedOnServer;
                creature.OnCriticalDamageMultiplierChanged += OnCriticalDamageMultiplierChangedOnServer;
            }
        }

        protected override void OnDestruct()
        {
            base.OnDestruct();
            
            if (InstanceFinder.IsServerStarted)
            {
                creature.OnPhysicalAttackChanged -= OnPhysicalAttackChangedOnServer;
                creature.OnMagicalAttackChanged -= OnMagicalAttackChangedOnServer;
                creature.OnCriticalRateChanged -= OnCriticalRateChangedOnServer;
                creature.OnCriticalDamageMultiplierChanged -= OnCriticalDamageMultiplierChangedOnServer;
            }
        }

        protected override void Awake()
        {
            base.Awake();
            
            physicalAttackOnServer.OnChange += OnPhysicalAttackOnServerChanged;
            magicalAttackOnServer.OnChange += OnMagicalAttackOnServerChanged;
            criticalRateOnServer.OnChange += OnCriticalRateOnServerChanged;
            criticalDamageMultiplierOnServer.OnChange += OnCriticalDamageMultiplierOnServerChanged;
        }

        private void OnPhysicalAttackOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue,
            bool asServer)
        {
            if (asServer == false || IsClientStarted)
            {
                creature.physicalAttackBaseValue = newValue.baseValue;
                creature.physicalAttackBoostValue = newValue.boostValue;
            }
        }

        private void OnMagicalAttackOnServerChanged(BaseBoostInt oldValue, BaseBoostInt newValue,
            bool asServer)
        {
            if (asServer == false || IsClientStarted)
            {
                creature.magicalAttackBaseValue = newValue.baseValue;
                creature.magicalAttackBoostValue = newValue.boostValue;
            }
        }

        private void OnCriticalRateOnServerChanged(float oldValue, float newValue, bool asServer)
        {
            if (asServer == false || IsClientStarted)
            {
                creature.criticalRate = newValue;
            }
        }

        private void OnCriticalDamageMultiplierOnServerChanged(float oldValue, float newValue, bool asServer)
        {
            if (asServer == false || IsClientStarted)
            {
                creature.criticalDamageMultiplier = newValue;
            }
        }

        private void OnPhysicalAttackChangedOnServer(IAttackOwner owner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            physicalAttackOnServer.Value = newValue;
        }
        
        private void OnMagicalAttackChangedOnServer(IAttackOwner owner, BaseBoostInt oldValue,
            BaseBoostInt newValue)
        {
            magicalAttackOnServer.Value = newValue;
        }

        private void OnCriticalRateChangedOnServer(IAttackOwner owner, float oldValue, float newValue)
        {
            criticalRateOnServer.Value = newValue;
        }

        private void OnCriticalDamageMultiplierChangedOnServer(IAttackOwner owner, float oldValue,
            float newValue)
        {
            criticalDamageMultiplierOnServer.Value = newValue;
        }
    }
}