using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface ISpeedOwner
    {
        public float speed { get; }
        
        public float speedBaseValue { get; set; }
        
        public float speedBoostValue { get; set; }

        public event Action<ISpeedOwner, BaseBoostFloat, BaseBoostFloat> OnSpeedChanged;
    }
}