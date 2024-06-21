using PVZRTS.Damage;
using UnityEngine;

namespace PVZRTS.Entities
{
    public class LinearBullet : Bullet, ILinearBullet
    {
        public Vector3 direction { get; private set; }

        public void InitProjectile(DamagePacket damagePacket, Vector3 direction)
        {
            this.damagePacket = damagePacket;
            this.direction = direction;
        }
    }
}