using PVZRTS.Entities;
using UnityEngine;
using VMFramework.Core;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    public sealed class LinearBulletSpellUnit : BulletSpellUnit
    {
        private ILinearBulletSpellUnitConfig linearBulletSpellUnitConfig =>
            (ILinearBulletSpellUnitConfig)gamePrefab;
        
        private IChooser<string> linearProjectileID;

        protected override void OnFirstCreated()
        {
            base.OnFirstCreated();

            linearProjectileID = linearBulletSpellUnitConfig.linearProjectileID;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            linearProjectileID.ResetChooser();
        }

        protected override void CreateProjectile(ISpell spell, SpellCastInfo spellCastInfo,
            Vector3 spawnPosition, Vector3 direction)
        {
            var linearBullet = IGameItem.Create<ILinearBullet>(linearProjectileID.GetValue());

            spellCastInfo.caster.ProduceDamagePacket(null, out var packet);
                        
            packet = ProcessDamagePacket(packet);

            linearBullet.InitProjectile(packet, spellCastInfo.mainDirection);

            EntityManager.CreateEntity(linearBullet, spawnPosition);
        }
    }
}