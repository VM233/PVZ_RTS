using FishNet.Serializing;
using PVZRTS.Properties;
using Sirenix.OdinInspector;
using TH.Spells;
using UnityEngine;
using VMFramework.GameLogicArchitecture;
using VMFramework.Network;

namespace PVZRTS.Entities
{
    public class ShooterPlant : Creature, IShooterPlant
    {
        protected IShooterPlantConfig shooterPlantConfig => (IShooterPlantConfig)gamePrefab;
        
        protected IShooterPlantController shooterPlantController => (IShooterPlantController)controller;
        
        [ShowInInspector]
        public ISpell shooterSpell { get; private set; }

        protected override void OnCreate()
        {
            base.OnCreate();

            shooterSpell = IGameItem.Create<ISpell>(shooterPlantConfig.shootingSpellID);
            shooterSpell.SetOwner(this);
        }

        protected override void OnInit()
        {
            base.OnInit();
            
            shooterSpell.OnCooldownEnd += ShooterSpellOnOnCooldownEnd;
            shooterSpell.SetToMaxCooldown();
        }

        private void ShooterSpellOnOnCooldownEnd(ICooldownOwner cooldownOwner)
        {
            shooterSpell.Cast(new SpellCastInfo(this, SpellTargetType.Direction, Vector3.right));
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            shooterSpell.OnCooldownEnd -= ShooterSpellOnOnCooldownEnd;
            shooterSpell = null;
        }

        #region Network Serialization

        protected override void OnWrite(Writer writer)
        {
            base.OnWrite(writer);
            
            writer.WriteString(shooterSpell.uuid);
        }

        protected override void OnRead(Reader reader)
        {
            base.OnRead(reader);

            shooterSpell.TrySetUUIDAndRegister(reader.ReadString());
        }

        #endregion

        #region Spell Self Caster

        Vector3 ISpellOwner.ownerCastingPosition => shooterPlantController.ownerCastingTransform.position;

        Vector3 ISpellCaster.casterPosition => shooterPlantController.transform.position;

        Vector3 ISpellCaster.casterCastingPosition => shooterPlantController.casterCastingTransform.position;

        #endregion
    }
}