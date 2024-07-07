using System;
using PVZRTS.Entities;
using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Configuration;
using VMFramework.Core;

namespace TH.Spells
{
    public partial class LinearBulletSpellUnitConfig : ProjectileSpellUnitConfig, ILinearBulletSpellUnitConfig
    {
        public override Type gameItemType => typeof(LinearBulletSpellUnit);

        public override SpellTargetType supportedTargetType =>
            SpellTargetType.Entities | SpellTargetType.Direction;
        
        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private IGamePrefabIDChooserConfig<ILinearBulletConfig> linearProjectileID;

        IChooser<string> ILinearBulletSpellUnitConfig.linearProjectileID =>
            linearProjectileID.GetObjectChooser();

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
    }
}