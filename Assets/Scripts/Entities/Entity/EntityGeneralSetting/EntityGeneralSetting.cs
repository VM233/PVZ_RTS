using System;
using VMFramework.GameLogicArchitecture;

namespace PVZRTS.Entities
{
    public sealed partial class EntityGeneralSetting : GamePrefabGeneralSetting
    {
        #region Meta Data

        public override Type baseGamePrefabType => typeof(IEntityConfig);

        public override string gameItemName => nameof(Entity);

        #endregion
    }
}