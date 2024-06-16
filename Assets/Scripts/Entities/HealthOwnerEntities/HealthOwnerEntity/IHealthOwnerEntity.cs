using PVZRTS.Damage;
using PVZRTS.Properties;

namespace PVZRTS.Entities
{
    public interface IHealthOwnerEntity : IEntity, IHealthOwner, IDefenseOwner, IDamageable
    {
        
    }
}