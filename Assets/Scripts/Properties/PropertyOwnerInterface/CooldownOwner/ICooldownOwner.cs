using System;
using VMFramework.Properties;

namespace PVZRTS.Properties
{
    public interface ICooldownOwner : ICooldownProvider
    {
        /// <summary>
        /// The event that is called when the cooldown ends.
        /// Only listen to this event if it's in server-side!
        /// </summary>
        public event Action<ICooldownOwner> OnCooldownEnd;
    }
}