using PVZRTS.Damage;
using PVZRTS.Properties;

namespace PVZRTS.Entities
{
    public interface ICreature : IHealthOwnerEntity, IDamageSource, IAttackOwner
    {
        
    }
}