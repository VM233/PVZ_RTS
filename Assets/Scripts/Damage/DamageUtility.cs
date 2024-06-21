using PVZRTS.Properties;
using UnityEngine;
using VMFramework.Core;

namespace PVZRTS.Damage
{
    public static class DamageUtility
    {
        public static void DefaultProcessDamagePacket(this IDamageable damageable, DamagePacket packet,
            out DamageResult result)
        {
            int physicalDefense = 0;
            int magicalDefense = 0;
            float defensePercent = 0;

            if (damageable is IDefenseOwner defenseOwner)
            {
                physicalDefense = defenseOwner.physicalDefense;
                magicalDefense = defenseOwner.magicalDefense;
                defensePercent = defenseOwner.defensePercent;
            }

            float physicalDamage = packet.physicalDamage - physicalDefense;
            float magicalDamage = packet.magicalDamage - magicalDefense;
            physicalDamage = physicalDamage.ClampMin(0);
            magicalDamage = magicalDamage.ClampMin(0);
            
            float damageFloat = physicalDamage + magicalDamage;
            
            damageFloat *= (1 - defensePercent).Clamp(0, 1);
            
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

            int damage = 0;

            if (damageFloat > 0)
            {
                damage = damageFloat.Floor();
            }
            else
            {
                damage = damageFloat.Ceiling();
            }
            
            result.healthChange = -damage;
            result.isCritical = isCritical;
        }
    }
}