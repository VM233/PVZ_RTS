using Sirenix.OdinInspector;
using UnityEngine;
using VMFramework.Configuration;
using VMFramework.Core;
using VMFramework.OdinExtensions;

namespace TH.Spells
{
    public abstract partial class ProjectileSpellUnitConfig : SpellUnitConfig, IProjectileSpellUnitConfig
    {
        protected const string PROJECTILE_CATEGORY = "Projectile";
        
        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private ProjectileDirectionRotationType directionRotationType;
        
        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [PreviewCompositeSettings("°")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> scatterAngle = new SingleVectorChooserConfig<float>(30f);

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private bool shuffleProjectiles = false;

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [Minimum(1)]
        [SerializeField]
        private IVectorChooserConfig<int> numbers = new SingleVectorChooserConfig<int>(1);

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [PreviewCompositeSettings("seconds")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> shootingInterval = new SingleVectorChooserConfig<float>(0);

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [EnumToggleButtons]
        [SerializeField]
        private ProjectileSpawnPosition projectileSpawnPosition;

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [PreviewCompositeSettings("seconds")]
        [Minimum(0)]
        [SerializeField]
        private IVectorChooserConfig<float> delay = new SingleVectorChooserConfig<float>(0);
        
        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private bool isMelee = false;
        
        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private IVectorChooserConfig<int> physicalAttack = new SingleVectorChooserConfig<int>(1);

        [TabGroup(TAB_GROUP_NAME, PROJECTILE_CATEGORY)]
        [SerializeField]
        private IVectorChooserConfig<int> magicalAttack = new SingleVectorChooserConfig<int>(1);

        #region Interface Implementation

        ProjectileDirectionRotationType IProjectileSpellUnitConfig.directionRotationType => directionRotationType;

        IChooser<float> IProjectileSpellUnitConfig.scatterAngle => scatterAngle.GetObjectChooser();

        bool IProjectileSpellUnitConfig.shuffleProjectiles => shuffleProjectiles;

        IChooser<int> IProjectileSpellUnitConfig.numbers => numbers.GetObjectChooser();

        IChooser<float> IProjectileSpellUnitConfig.shootingInterval => shootingInterval.GetObjectChooser();

        ProjectileSpawnPosition IProjectileSpellUnitConfig.projectileSpawnPosition => projectileSpawnPosition;

        IChooser<float> IProjectileSpellUnitConfig.delay => delay.GetObjectChooser();

        bool IProjectileSpellUnitConfig.isMelee => isMelee;

        IChooser<int> IProjectileSpellUnitConfig.physicalAttack => physicalAttack.GetObjectChooser();

        IChooser<int> IProjectileSpellUnitConfig.magicalAttack => magicalAttack.GetObjectChooser();

        #endregion

        public override void CheckSettings()
        {
            base.CheckSettings();
            
            scatterAngle.CheckSettings();
            numbers.CheckSettings();
            shootingInterval.CheckSettings();
            delay.CheckSettings();
            physicalAttack.CheckSettings();
            magicalAttack.CheckSettings();
        }

        protected override void OnInit()
        {
            base.OnInit();
            
            scatterAngle.Init();
            numbers.Init();
            shootingInterval.Init();
            delay.Init();
            physicalAttack.Init();
            magicalAttack.Init();
        }
    }
}