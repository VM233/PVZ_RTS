using System;
using System.Globalization;
using VMFramework.GameLogicArchitecture;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    [GamePrefabTypeAutoRegister(ID)]
    public sealed class SpeedProperty : GameProperty
    {
        public const string ID = "speed_property";
        
        public override Type targetType => typeof(ISpeedOwner);

        public override string GetValueString(object target)
        {
            ISpeedOwner speedOwner = (ISpeedOwner)target;
            return speedOwner.speed.ToString(CultureInfo.InvariantCulture);
        }
    }
}