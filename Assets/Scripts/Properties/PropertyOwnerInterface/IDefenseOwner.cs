using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IDefenseOwner
    {
        public int defense { get; }
        
        public int defenseBaseValue { get; set; }
        
        public float defenseBoostValue { get; set; }
        
        public float defensePercent { get; set; }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnDefenseChanged;

        public event Action<IDefenseOwner, float, float> OnDefensePercentChanged;
    }
}