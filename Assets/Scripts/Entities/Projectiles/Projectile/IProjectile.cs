using PVZRTS.Damage;
using VMFramework.Timers;

namespace PVZRTS.Entities
{
    public interface IProjectile : IEntity, IDamageSource, ITimer
    {
        public DamagePacket damagePacket { get; }
    }
}