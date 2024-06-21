using PVZRTS.Damage;
using VMFramework.Core;
using VMFramework.Timers;

namespace PVZRTS.Entities
{
    public class Projectile : Entity, IProjectile
    {
        protected IProjectileConfig projectileConfig => (IProjectileConfig)gamePrefab;
        
        public DamagePacket damagePacket { get; protected set; }

        private int damageCount = 0;

        protected override void OnCreate()
        {
            base.OnCreate();

            damageCount = 0;
            
            TimerManager.Add(this, projectileConfig.maxLifeTime);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (TimerManager.Contains(this))
            {
                TimerManager.Stop(this);
            }
        }

        void IDamageSource.ProduceDamagePacket(IDamageable target, out DamagePacket packet)
        {
            packet = damagePacket;

            if (projectileConfig.hasMaxDamageCount)
            {
                damageCount++;

                if (damageCount >= projectileConfig.maxDamageCount)
                {
                    EntityManager.DestroyEntity(this);
                }
            }
        }

        void ITimer.OnTimed()
        {
            EntityManager.DestroyEntity(this);
        }

        #region Priority Queue

        private double priority;
        private int queueIndex;
        private long insertionIndex;

        double IGenericPriorityQueueNode<double>.Priority
        {
            get => priority;
            set => priority = value;
        }

        int IGenericPriorityQueueNode<double>.QueueIndex
        {
            get => queueIndex;
            set => queueIndex = value;
        }

        long IGenericPriorityQueueNode<double>.InsertionIndex
        {
            get => insertionIndex;
            set => insertionIndex = value;
        }

        #endregion
    }
}