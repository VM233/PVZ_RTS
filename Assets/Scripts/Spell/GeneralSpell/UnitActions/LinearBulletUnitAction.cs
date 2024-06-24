using PVZRTS.Damage;
using PVZRTS.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Configuration;
using VMFramework.GameLogicArchitecture;

namespace TH.Spells
{
    [TypeInfoBox("Linear Bullet")]
    public sealed partial class LinearBulletUnitAction : BulletUnitAction
    {
        public override SpellTargetType supportedTargetType =>
            SpellTargetType.Entities | SpellTargetType.Direction;
        
        [SerializeField]
        private IGamePrefabIDChooserConfig<ILinearBulletConfig> linearProjectileID;

        public override void CheckSettings()
        {
            base.CheckSettings();
            
            linearProjectileID.CheckSettings();
        }

        protected override void OnInit()
        {
            base.OnInit();
            
            linearProjectileID.Init();
        }

        protected override void CreateProjectile(ISpell spell, SpellCastInfo spellCastInfo,
            Vector3 spawnPosition, Vector3 direction)
        {
            var linearBullet = IGameItem.Create<ILinearBullet>(linearProjectileID.GetID());

            spellCastInfo.caster.ProduceDamagePacket(null, out var packet);
                        
            packet = ProcessDamagePacket(packet);

            linearBullet.InitProjectile(packet, spellCastInfo.mainDirection);

            EntityManager.CreateEntity(linearBullet, spawnPosition);
        }
    }
}