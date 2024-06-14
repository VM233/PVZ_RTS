using System;
using VMFramework.GameLogicArchitecture;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    [GamePrefabTypeAutoRegister(ID)]
    public sealed class MagicalAttackProperty : GameProperty
    {
        public const string ID = "magical_attack_property";

        public override Type targetType => typeof(IAttackOwner);

        public override string GetValueString(object target)
        {
            IAttackOwner attackOwner = (IAttackOwner)target;
            return attackOwner.magicalAttack.ToString();
        }
    }
}