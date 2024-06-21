using System;
using PVZRTS.Damage;
using UnityEngine;

namespace PVZRTS.Entities
{
    public abstract class BulletController : ProjectileController
    {
        protected IBullet bullet => (IBullet)entity;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IDamageableController damageableController))
            {
                bullet.RequestTakeDamage(damageableController.damageable);
            }
        }
    }
}