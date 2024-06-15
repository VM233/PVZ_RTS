using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IAttackOwner
    {
        /// <summary>
        /// 物理攻击力 = 物理攻击力基础值 * 物理攻击力提升值
        /// </summary>
        public int physicalAttack { get; }
        
        /// <summary>
        /// 物理攻击力基础值
        /// </summary>
        public int physicalAttackBaseValue { get; set; }
        
        /// <summary>
        /// 物理攻击力提升值
        /// </summary>
        public float physicalAttackBoostValue { get; set; }

        public event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> OnPhysicalAttackChanged;
        
        /// <summary>
        /// 魔法攻击力 = 魔法攻击力基础值 * 魔法攻击力提升值
        /// </summary>
        public int magicalAttack { get; }
        
        /// <summary>
        /// 魔法攻击力基础值
        /// </summary>
        public int magicalAttackBaseValue { get; set; }
        
        /// <summary>
        /// 魔法攻击力提升值
        /// </summary>
        public float magicalAttackBoostValue { get; set; }

        public event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> OnMagicalAttackChanged;
        
        /// <summary>
        /// 暴击率
        /// </summary>
        public float criticalRate { get; set; }
        
        public event Action<IAttackOwner, float, float> OnCriticalRateChanged;
        
        /// <summary>
        /// 暴击伤害倍率（或者叫暴击倍率），即触发暴击后的伤害增幅
        /// </summary>
        public float criticalDamageMultiplier { get; set; }

        public event Action<IAttackOwner, float, float> OnCriticalDamageMultiplierChanged;
    }
}