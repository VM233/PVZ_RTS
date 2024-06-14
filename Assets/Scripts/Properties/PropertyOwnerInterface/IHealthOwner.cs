using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IHealthOwner
    {
        public int maxHealth { get; }
        
        public int maxHealthBaseValue { get; set; }
        
        public float maxHealthBoostValue { get; set; }
        
        public int health { get; set; }

        public event Action<IHealthOwner, BaseBoostInt, BaseBoostInt> OnMaxHealthChanged;
        
        public event Action<IHealthOwner, int, int> OnHealthChanged;
    }
}