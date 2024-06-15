using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IDefenseOwner
    {
        /// <summary>
        /// 防御力 = 基础防御力 * 防御力增幅
        /// </summary>
        public int defense { get; }
        
        /// <summary>
        /// 基础防御力
        /// </summary>
        public int defenseBaseValue { get; set; }
        
        /// <summary>
        /// 防御力增幅
        /// </summary>
        public float defenseBoostValue { get; set; }
        
        /// <summary>
        /// 防御力百分比，可以按百分比减少伤害
        /// </summary>
        public float defensePercent { get; set; }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnDefenseChanged;

        public event Action<IDefenseOwner, float, float> OnDefensePercentChanged;
    }
}