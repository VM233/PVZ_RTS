using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface ISpeedOwner
    {
        /// <summary>
        /// 速度 = 速度基础值 * 速度提升值
        /// </summary>
        public float speed { get; }
        
        /// <summary>
        /// 速度基础值
        /// </summary>
        public float speedBaseValue { get; set; }
        
        /// <summary>
        /// 速度提升值
        /// </summary>
        public float speedBoostValue { get; set; }

        public event Action<ISpeedOwner, BaseBoostFloat, BaseBoostFloat> OnSpeedChanged;
    }
}