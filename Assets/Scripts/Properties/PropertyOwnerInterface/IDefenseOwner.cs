using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IDefenseOwner
    {
        /// <summary>
        /// 物理防御力 = 基础物理防御力 * 物理防御力增幅
        /// </summary>
        public int physicalDefense { get; }
        
        /// <summary>
        /// 物理基础防御力
        /// </summary>
        public int physicalDefenseBaseValue { get; set; }
        
        /// <summary>
        /// 物理防御力增幅
        /// </summary>
        public float physicalDefenseBoostValue { get; set; }

        /// <summary>
        /// 魔法防御力 = 基础魔法防御力 * 魔法防御力增幅
        /// </summary>
        public int magicalDefense { get; }
        
        /// <summary>
        /// 魔法基础防御力
        /// </summary>
        public int magicalDefenseBaseValue { get; set; }
        
        /// <summary>
        /// 魔法防御力增幅
        /// </summary>
        public float magicalDefenseBoostValue { get; set; }
        
        /// <summary>
        /// 防御力百分比，可以按百分比减少伤害
        /// </summary>
        public float defensePercent { get; set; }

        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnPhysicalDefenseChanged;
        
        public event Action<IDefenseOwner, BaseBoostInt, BaseBoostInt> OnMagicalDefenseChanged;

        public event Action<IDefenseOwner, float, float> OnDefensePercentChanged;
    }
}