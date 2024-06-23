using System;
using Sirenix.OdinInspector;
using TH.Spells;
using VMFramework.OdinExtensions;

namespace PVZRTS.Entities
{
    public class ShooterPlantConfig : CreatureConfig, IShooterPlantConfig
    {
        public override Type gameItemType => typeof(ShooterPlant);

        protected override Type controllerType => typeof(IShooterPlantController);

        [GamePrefabID(typeof(ISpellConfig))]
        public string shootingSpellID;

        #region Interface Implementation

        string IShooterPlantConfig.shootingSpellID => shootingSpellID;

        #endregion
    }
}