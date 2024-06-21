using FishNet;
using UnityEngine;

namespace PVZRTS.Entities
{
    public class LinearBulletController : BulletController
    {
        protected ILinearBullet linearBullet => (ILinearBullet)entity;
        
        // protected override void OnPreInit()
        // {
        //     base.OnPreInit();
        //
        //     if (InstanceFinder.IsServerStarted)
        //     {
        //         GetComponent<Rigidbody>().velocity = linearBullet.direction * linearBullet.speed;
        //     }
        // }

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