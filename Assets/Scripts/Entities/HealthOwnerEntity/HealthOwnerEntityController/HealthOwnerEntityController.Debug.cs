#if UNITY_EDITOR
using PVZRTS.Damage;
using Sirenix.OdinInspector;

namespace PVZRTS.Entities
{
    public partial class HealthOwnerEntityController
    {
        [Button]
        private void ReceiveDamage(DamagePacket packet)
        {
            healthOwnerEntity.ReceiveDamagePacket(packet);
        }
    }
}
#endif