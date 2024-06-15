using System;
using VMFramework.GameLogicArchitecture;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    [GamePrefabTypeAutoRegister(ID)]
    public sealed class DefenseProperty : GameProperty
    {
        public const string ID = "defense_property";
        
        public override Type targetType => typeof(IDefenseOwner);

        public override string GetValueString(object target)
        {
            IDefenseOwner defenseOwner = (IDefenseOwner)target;
            return defenseOwner.physicalDefense.ToString();
        }
    }
}