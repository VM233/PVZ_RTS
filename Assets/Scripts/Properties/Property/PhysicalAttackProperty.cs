using System;
using VMFramework.GameLogicArchitecture;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    [GamePrefabTypeAutoRegister(ID)]
    public sealed class PhysicalAttackProperty : GameProperty
    {
        public const string ID = "physical_attack_property";
        
        public override Type targetType => typeof(IAttackOwner);

        public override string GetValueString(object target)
        {
            IAttackOwner owner = (IAttackOwner)target;
            return owner.physicalAttack.ToString();
        }
    }
}