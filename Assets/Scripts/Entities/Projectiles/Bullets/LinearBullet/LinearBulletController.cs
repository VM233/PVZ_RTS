using FishNet;
using UnityEngine;

namespace PVZRTS.Entities
{
    public class LinearBulletController : BulletController, ILinearBulletController
    {
        protected ILinearBullet linearBullet => (ILinearBullet)entity;

        protected override void OnPostInit()
        {
            base.OnPostInit();
            
            if (IsServerStarted)
            {
                GetComponent<Rigidbody>().velocity = linearBullet.direction * linearBullet.speed;
            }
        }
    }
}