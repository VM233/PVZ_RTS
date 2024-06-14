using System;
using VMFramework.GameLogicArchitecture;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    [GamePrefabTypeAutoRegister(ID)]
    public sealed class HealthProperty : GameProperty
    {
        public const string ID = "health_property";
        
        public override Type targetType => typeof(IHealthOwner);

        public override string GetValueString(object target)
        {
            IHealthOwner owner = (IHealthOwner)target;
            return $"{owner.health}/{owner.maxHealth}";
        }
    }
}