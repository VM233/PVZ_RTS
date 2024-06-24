using System;
using PVZRTS.Damage;
using UnityEngine;

namespace PVZRTS.Entities
{
    public abstract class BulletController : ProjectileController, IBulletController
    {
        protected IBullet bullet => (IBullet)entity;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageableController damageableController))
            {
                if (damageableController.damageable == bullet.damagePacket.directSource)
                {
                    return;
                }
                
                bullet.RequestTakeDamage(damageableController.damageable);
            }
        }
    }
}