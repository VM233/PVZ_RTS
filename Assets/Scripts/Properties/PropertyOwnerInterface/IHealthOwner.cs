using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IHealthOwner
    {
        /// <summary>
        /// 最大生命值 = 基础值 * 提升值
        /// </summary>
        public int maxHealth { get; }
        
        /// <summary>
        /// 最大生命值的基础值
        /// </summary>
        public int maxHealthBaseValue { get; set; }
        
        /// <summary>
        /// 最大生命值的提升值
        /// </summary>
        public float maxHealthBoostValue { get; set; }
        
        /// <summary>
        /// 当前生命值
        /// </summary>
        public int health { get; set; }

        public event Action<IHealthOwner, BaseBoostInt, BaseBoostInt> OnMaxHealthChanged;
        
        public event Action<IHealthOwner, int, int> OnHealthChanged;
    }
}