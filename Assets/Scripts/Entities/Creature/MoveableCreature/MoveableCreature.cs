using System;
using PVZRTS.Properties;
using VMFramework.Properties;

namespace PVZRTS.Entities
{
    public class MoveableCreature : Creature, IControllableEntity
    {
        protected IMoveableCreatureConfig moveableCreatureConfig => (IMoveableCreatureConfig)gamePrefab;

        public BaseBoostFloatProperty<ISpeedOwner> speed;

        protected override void OnCreate()
        {
            base.OnCreate();

            speed = new(this, moveableCreatureConfig.defaultSpeed);
        }

        #region Interface Implementations

        float ISpeedOwner.speed => speed;

        float ISpeedOwner.speedBaseValue
        {
            get => speed.baseValue;
            set => speed.baseValue = value;
        }

        float ISpeedOwner.speedBoostValue
        {
            get => speed.boostValue;
            set => speed.boostValue = value;
        }

        event Action<ISpeedOwner, BaseBoostFloat, BaseBoostFloat> ISpeedOwner.OnSpeedChanged
        {
            add => speed.OnValueChanged += value;
            remove => speed.OnValueChanged -= value;
        }

        #endregion
    }
}