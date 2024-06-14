using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface IAttackOwner
    {
        public int physicalAttack { get; }
        
        public int physicalAttackBaseValue { get; set; }
        
        public float physicalAttackBoostValue { get; set; }

        public event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> OnPhysicalAttackChanged;
        
        public int magicalAttack { get; }
        
        public int magicalAttackBaseValue { get; set; }
        
        public float magicalAttackBoostValue { get; set; }

        public event Action<IAttackOwner, BaseBoostInt, BaseBoostInt> OnMagicalAttackChanged;
        
        public float criticalRate { get; set; }
        
        public event Action<IAttackOwner, float, float> OnCriticalRateChanged;
        
        public float criticalDamageMultiplier { get; set; }

        public event Action<IAttackOwner, float, float> OnCriticalDamageMultiplierChanged;
    }
}