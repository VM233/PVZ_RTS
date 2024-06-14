using System;
using PVZRTS.Damage;
using PVZRTS.Properties;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public class Creature : HealthOwnerEntity, ICreature
    {
        protected ICreatureConfig creatureConfig => (ICreatureConfig)gamePrefab;
        
        public BaseBoostIntProperty<IAttackOwner> physicalAttack;
        
        public BaseBoostIntProperty<IAttackOwner> magicalAttack;

        public BaseFloatProperty<IAttackOwner> criticalRate;
        
        public BaseFloatProperty<IAttackOwner> criticalDamageMultiplier;

        protected override void OnCreate()
        {
            base.OnCreate();

            physicalAttack = new(this, creatureConfig.defaultPhysicalAttack);
            magicalAttack = new(this, creatureConfig.defaultMagicalAttack);
            criticalRate = new(this, creatureConfig.defaultCriticalRate);
            criticalDamageMultiplier = new(this, creatureConfig.defaultCriticalDamageMultiplier);
        }

        #region Damage

        protected virtual void ProduceDamagePacket(IDamageable target, out DamagePacket packet)
        {
            packet = new DamagePacket(this, this);
        }

        void IDamageSource.ProduceDamagePacket(IDamageable target, out DamagePacket packet)
        {
            ProduceDamagePacket(target, out packet);
        }

        #endregion

        #region Interface Implementation

        int IAttackOwner.physicalAttack => physicalAttack;

        int IAttackOwner.physicalAttackBaseValue
        {
            get => physicalAttack.baseValue;
            set => physicalAttack.baseValue = value;
        }

        float IAttackOwner.physicalAttackBoostValue
        {
            get => physicalAttack.boostValue;
            set => physicalAttack.boostValue = value;
        }

        event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> IAttackOwner.OnPhysicalAttackChanged
        {
            add => physicalAttack.OnValueChanged += value;
            remove => physicalAttack.OnValueChanged -= value;
        }

        int IAttackOwner.magicalAttack => magicalAttack;

        int IAttackOwner.magicalAttackBaseValue
        {
            get => magicalAttack.baseValue;
            set => magicalAttack.baseValue = value;
        }

        float IAttackOwner.magicalAttackBoostValue
        {
            get => magicalAttack.boostValue;
            set => magicalAttack.boostValue = value;
        }

        event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> IAttackOwner.OnMagicalAttackChanged
        {
            add => magicalAttack.OnValueChanged += value;
            remove => magicalAttack.OnValueChanged -= value;
        }

        float IAttackOwner.criticalRate
        {
            get => criticalRate.value;
            set => criticalRate.value = value;
        }

        event Action<IAttackOwner, float, float> IAttackOwner.OnCriticalRateChanged
        {
            add => criticalRate.OnValueChanged += value;
            remove => criticalRate.OnValueChanged -= value;
        }

        float IAttackOwner.criticalDamageMultiplier
        {
            get => criticalDamageMultiplier.value;
            set => criticalDamageMultiplier.value = value;
        }

        event Action<IAttackOwner, float, float> IAttackOwner.OnCriticalDamageMultiplierChanged
        {
            add => criticalDamageMultiplier.OnValueChanged += value;
            remove => criticalDamageMultiplier.OnValueChanged -= value;
        }

        #endregion
    }
}