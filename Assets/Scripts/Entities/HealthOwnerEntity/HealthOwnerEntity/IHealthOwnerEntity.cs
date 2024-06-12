using PVZRTS.Damage;

namespace PVZRTS.Entities
{
    public interface IHealthOwnerEntity : IEntity, IHealthOwner, IDefenseOwner, IDamageable
    {
        
    }
}