using System;
using FishNet.Serializing;
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
        public BaseBoostIntProperty<IDefenseOwner> physicalDefense;

        [ShowInInspector]
        public BaseBoostIntProperty<IDefenseOwner> magicalDefense;
        
        [ShowInInspector]
        public BaseFloatProperty<IDefenseOwner> defensePercent;

        protected override void OnCreate()
        {
            base.OnCreate();

            maxHealth = new(this, healthOwnerEntityConfig.defaultMaxHealth);
            health = new(this, healthOwnerEntityConfig.defaultMaxHealth);
            
            physicalDefense = new(this, healthOwnerEntityConfig.defaultPhysicalDefense);
            magicalDefense = new(this, healthOwnerEntityConfig.defaultMagicalDefense);
            defensePercent = new(this, healthOwnerEntityConfig.defaultDefensePercent);
        }

        protected override void OnInit()
        {
            base.OnInit();
            
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

        #region Network Serialization

        protected override void OnWrite(Writer writer)
        {
            base.OnWrite(writer);
            
            writer.WriteBaseBoostInt(maxHealth);
            writer.WriteInt32(health);
            writer.WriteBaseBoostInt(physicalDefense);
            writer.WriteBaseBoostInt(magicalDefense);
            writer.WriteSingle(defensePercent);
        }

        protected override void OnRead(Reader reader)
        {
            base.OnRead(reader);
            
            maxHealth.SetBaseBoost(reader.ReadBaseBoostInt());
            health.value = reader.ReadInt32();
            physicalDefense.SetBaseBoost(reader.ReadBaseBoostInt());
            magicalDefense.SetBaseBoost(reader.ReadBaseBoostInt());
            defensePercent.value = reader.ReadSingle();
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

        int IDefenseOwner.physicalDefense => physicalDefense;

        int IDefenseOwner.physicalDefenseBaseValue
        {
            get => physicalDefense.baseValue;
            set => physicalDefense.baseValue = value;
        }

        float IDefenseOwner.physicalDefenseBoostValue
        {
            get => physicalDefense.boostValue;
            set => physicalDefense.boostValue = value;
        }
        
        int IDefenseOwner.magicalDefense => magicalDefense;

        int IDefenseOwner.magicalDefenseBaseValue
        {
            get => magicalDefense.baseValue;
            set => magicalDefense.baseValue = value;
        }

        float IDefenseOwner.magicalDefenseBoostValue
        {
            get => magicalDefense.boostValue;
            set => magicalDefense.boostValue = value;
        }

        float IDefenseOwner.defensePercent
        {
            get => defensePercent;
            set => defensePercent.value = value;
        }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnPhysicalDefenseChanged
        {
            add => physicalDefense.OnValueChanged += value;
            remove => physicalDefense.OnValueChanged -= value;
        }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnMagicalDefenseChanged
        {
            add => magicalDefense.OnValueChanged += value;
            remove => magicalDefense.OnValueChanged -= value;
        }

        public event Action<IDefenseOwner, float, float> OnDefensePercentChanged
        {
            add => defensePercent.OnValueChanged += value;
            remove => defensePercent.OnValueChanged -= value;
        }

        #endregion
    }
}