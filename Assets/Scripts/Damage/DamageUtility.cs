using PVZRTS.Damage;
using UnityEngine;
using VMFramework.Core;

namespace PVZRTS.Damage
{
    public static class DamageUtility
    {
        public static void DefaultProcessDamagePacket(this IDamageable damageable, DamagePacket packet,
            out DamageResult result)
        {
            int defense = 0;
            float defensePercent = 0;

            if (damageable is IDefenseOwner defenseOwner)
            {
                defense = defenseOwner.defense;
                defensePercent = defenseOwner.defensePercent;
            }

            float damageFloat = packet.physicalDamage + packet.magicalDamage;
            if (damageFloat > 0)
            {
                damageFloat -= defense;
                damageFloat = damageFloat.ClampMin(0);
                damageFloat *= (1 - defensePercent).Clamp(0, 1);
            }
            damageFloat *= packet.damageMultiplier.ClampMin(0);

            bool isCritical = false;
            if (packet.criticalRate > 0)
            {
                if (Random.value < packet.criticalRate)
                {
                    damageFloat *= packet.criticalDamageMultiplier;
                    isCritical = true;
                }
            }

            var damage = damageFloat.Floor();
            
            result.healthChange = -damage;
            result.isCritical = isCritical;
        }
    }
}