using System;
using PVZRTS.Damage;
using PVZRTS.Properties;
using Sirenix.OdinInspector;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public class HealthOwnerEntity : Entity, IHealthOwnerEntity
    {
        protected IHealthOwnerEntityConfig healthOwnerEntityConfig => (IHealthOwnerEntityConfig)gamePrefab;
        
        [ShowInInspector]
        public BaseBoostIntProperty<IHealthOwner> maxHealth;

        [ShowInInspector]
        public BaseIntProperty<IHealthOwner> health;

        [ShowInInspector]
        public BaseBoostIntProperty<IDefenseOwner> defense;
        
        [ShowInInspector]
        public BaseFloatProperty<IDefenseOwner> defensePercent;

        protected override void OnCreate()
        {
            base.OnCreate();

            maxHealth = new(this, healthOwnerEntityConfig.defaultMaxHealth);
            health = new(this, healthOwnerEntityConfig.defaultMaxHealth);
            
            defense = new(this, 0);
            defensePercent = new(this, 0);
            
            health.OnValueChanged += OnHealthChanged;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            
            health.OnValueChanged -= OnHealthChanged;
        }

        #region Health Changed

        private void OnHealthChanged(IHealthOwner owner, int oldValue, int newValue)
        {
            DamageUIUtility.PopupHealthChange(newValue - oldValue, controller.transform.position);
        }

        #endregion

        #region Damage

        public event Action<DamageResult> OnDamageTaken;

        protected virtual void ProcessDamageResult(DamageResult result)
        {
            health.value += result.healthChange;

            if (health.value <= 0)
            {
                EntityManager.DestroyEntity(this);
            }
        }
        
        void IDamageable.ProcessDamageResult(DamageResult result)
        {
            ProcessDamageResult(result);
            
            OnDamageTaken?.Invoke(result);
        }

        public virtual bool CanBeDamaged(IDamageSource source)
        {
            return true;
        }

        #endregion

        #region Interface Implementation

        int IHealthOwner.maxHealth => maxHealth;

        int IHealthOwner.maxHealthBaseValue
        {
            get => maxHealth.baseValue;
            set => maxHealth.baseValue = value;
        }

        float IHealthOwner.maxHealthBoostValue
        {
            get => maxHealth.boostValue;
            set => maxHealth.boostValue = value;
        }

        int IHealthOwner.health
        {
            get => health;
            set => health.value = value;
        }

        event Action<IHealthOwner, BaseBoostInt, BaseBoostInt> IHealthOwner.OnMaxHealthChanged
        {
            add => maxHealth.OnValueChanged += value;
            remove => maxHealth.OnValueChanged -= value;
        }

        event Action<IHealthOwner, int, int> IHealthOwner.OnHealthChanged
        {
            add => health.OnValueChanged += value;
            remove => health.OnValueChanged -= value;
        }

        int IDefenseOwner.defense => defense;

        int IDefenseOwner.defenseBaseValue
        {
            get => defense.baseValue;
            set => defense.baseValue = value;
        }

        float IDefenseOwner.defenseBoostValue
        {
            get => defense.boostValue;
            set => defense.boostValue = value;
        }

        float IDefenseOwner.defensePercent
        {
            get => defensePercent;
            set => defensePercent.value = value;
        }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnDefenseChanged
        {
            add => defense.OnValueChanged += value;
            remove => defense.OnValueChanged -= value;
        }

        public event Action<IDefenseOwner, float, float> OnDefensePercentChanged
        {
            add => defensePercent.OnValueChanged += value;
            remove => defensePercent.OnValueChanged -= value;
        }

        #endregion
    }
}