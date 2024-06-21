using PVZRTS.Damage;
using UnityEngine;

namespace PVZRTS.Entities
{
    public interface ILinearBullet : IBullet
    {
        public Vector3 direction { get; }

        public void InitProjectile(DamagePacket damagePacket, Vector3 direction);
    }
}